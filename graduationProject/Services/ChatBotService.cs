using graduationProject.Configurations;
using graduationProject.DTOs;
using graduationProject.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace graduationProject.Services
{
    public class ChatBotService : IChatBotService
    {
        private readonly GeminiChatBotSettings _settings;
        private readonly ILogger<ChatBotService> _logger;
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _cache;
        
        private const int MAX_HISTORY_MESSAGES = 20;
        private const int SESSION_CACHE_MINUTES = 60;

        public ChatBotService(
            IOptions<GeminiChatBotSettings> settings,
            ILogger<ChatBotService> logger,
            HttpClient httpClient,
            IMemoryCache cache)
        {
            _settings = settings.Value;
            _logger = logger;
            _httpClient = httpClient;
            _cache = cache;
            
            _httpClient.Timeout = TimeSpan.FromSeconds(_settings.TimeoutSeconds);
        }

        public async Task<ChatMessageResponseDto> SendMessageAsync(string userId, ChatMessageRequestDto request)
        {
            try
            {
                var session = await GetOrCreateSessionAsync(userId, request.SessionId, request.IsFirstContact);
                
                // Handle first contact persona selection
                if (request.IsFirstContact || session.BotPersona == BotPersona.NotSet.ToString())
                {
                    var personaResult = await HandlePersonaSelectionAsync(session, request.Message);
                    if (personaResult != null)
                    {
                        UpdateSessionCache(session);
                        return personaResult;
                    }
                }

                // Add user message to history
                session.Messages.Add(new ChatHistoryItemDto
                {
                    Role = "user",
                    Content = request.Message,
                    Timestamp = DateTime.UtcNow
                });

                // Generate AI response
                var aiResponse = await GenerateAIResponseAsync(session);
                
                // Add AI message to history
                session.Messages.Add(new ChatHistoryItemDto
                {
                    Role = "assistant",
                    Content = aiResponse,
                    Timestamp = DateTime.UtcNow
                });

                // Trim history if too long
                TrimSessionHistory(session);
                
                // Update cache
                UpdateSessionCache(session);

                return new ChatMessageResponseDto
                {
                    Message = aiResponse,
                    SessionId = session.SessionId,
                    BotPersona = session.BotPersona,
                    Status = ChatResponseStatus.Success
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in SendMessageAsync for user {UserId}", userId);
                return new ChatMessageResponseDto
                {
                    Status = ChatResponseStatus.Error,
                    Error = "I'm experiencing some technical difficulties. Please try again."
                };
            }
        }

        public async IAsyncEnumerable<string> SendMessageStreamAsync(string userId, ChatMessageRequestDto request)
        {
            // TEMPORARY: Use regular response for reliability
            var regularResponse = await SendMessageAsync(userId, request);
            yield return regularResponse.Message;
            yield break;
        }

        public async Task<ChatSessionDto?> GetChatSessionAsync(string userId, string? sessionId = null)
        {
            var cacheKey = sessionId ?? $"chat_session_{userId}_default";
            
            if (_cache.TryGetValue(cacheKey, out ChatSessionDto? session))
            {
                return session;
            }

            return null;
        }

        public async Task<bool> ClearChatSessionAsync(string userId, string sessionId)
        {
            var cacheKey = sessionId;
            _cache.Remove(cacheKey);
            
            _logger.LogInformation("Cleared chat session {SessionId} for user {UserId}", sessionId, userId);
            return true;
        }

        public async Task<List<ChatSessionDto>> GetUserChatSessionsAsync(string userId)
        {
            // Get all sessions for a user from cache
            var sessions = new List<ChatSessionDto>();
            
            // Get session list from cache or create new one
            var sessionListKey = $"user_sessions_{userId}";
            if (_cache.TryGetValue(sessionListKey, out List<string>? sessionIds))
            {
                foreach (var sessionId in sessionIds!)
                {
                    if (_cache.TryGetValue(sessionId, out ChatSessionDto? session))
                    {
                        sessions.Add(session!);
                    }
                }
            }

            // Sort by last activity (most recent first)
            sessions = sessions.OrderByDescending(s => s.LastActivity).ToList();
            return sessions;
        }

        private async Task<ChatSessionDto> GetOrCreateSessionAsync(string userId, string? sessionId, bool isFirstContact)
        {
            // Generate unique session ID if not provided
            var actualSessionId = sessionId ?? $"session_{userId}_{DateTime.UtcNow:yyyyMMdd_HHmmss}_{Guid.NewGuid().ToString("N")[..8]}";
            
            if (_cache.TryGetValue(actualSessionId, out ChatSessionDto? session) && !isFirstContact)
            {
                session!.LastActivity = DateTime.UtcNow;
                UpdateSessionCache(session);
                return session;
            }

            // Create new session
            var newSession = new ChatSessionDto
            {
                SessionId = actualSessionId,
                UserId = userId,
                BotPersona = BotPersona.NotSet.ToString(),
                CreatedAt = DateTime.UtcNow,
                LastActivity = DateTime.UtcNow,
                Messages = new List<ChatHistoryItemDto>()
            };

            if (isFirstContact)
            {
                // Add welcome message
                newSession.Messages.Add(new ChatHistoryItemDto
                {
                    Role = "assistant",
                    Content = "👋 Welcome to Nutrix! I'm your AI assistant. To provide you with the best personalized guidance, I'd like to know: **Are you looking for a Nutrition Coach or a Fitness Coach?**\n\nPlease type either **'Nutrition Coach'** or **'Fitness Coach'** to get started!",
                    Timestamp = DateTime.UtcNow
                });
            }

            // Update session in cache and user's session list
            UpdateSessionCache(newSession);
            UpdateUserSessionsList(userId, actualSessionId);
            
            return newSession;
        }

        private async Task<ChatMessageResponseDto?> HandlePersonaSelectionAsync(ChatSessionDto session, string message)
        {
            var lowerMessage = message.ToLowerInvariant().Trim();
            
            BotPersona selectedPersona;
            string responseMessage;

            if (lowerMessage.Contains("nutrition") || lowerMessage.Contains("diet") || lowerMessage.Contains("food"))
            {
                selectedPersona = BotPersona.NutritionCoach;
                responseMessage = "🥗 Perfect! I'm now your **Nutrition Coach**. I'll help you with meal planning, dietary advice, nutritional information, and healthy eating habits. What nutrition question can I help you with today?";
            }
            else if (lowerMessage.Contains("fitness") || lowerMessage.Contains("workout") || lowerMessage.Contains("exercise") || lowerMessage.Contains("training"))
            {
                selectedPersona = BotPersona.FitnessCoach;
                responseMessage = "💪 Excellent! I'm now your **Fitness Coach**. I'll help you with workout routines, exercise techniques, training plans, and fitness goals. What fitness question can I help you with today?";
            }
            else
            {
                return new ChatMessageResponseDto
                {
                    Message = "I need to know which type of coach you'd prefer! Please type either **'Nutrition Coach'** for dietary guidance or **'Fitness Coach'** for workout assistance. This helps me tailor my responses to your specific needs! 😊",
                    SessionId = session.SessionId,
                    BotPersona = session.BotPersona,
                    Status = ChatResponseStatus.Success
                };
            }

            session.BotPersona = selectedPersona.ToString();
            
            // Add the persona selection to history
            session.Messages.Add(new ChatHistoryItemDto
            {
                Role = "user",
                Content = message,
                Timestamp = DateTime.UtcNow
            });

            session.Messages.Add(new ChatHistoryItemDto
            {
                Role = "assistant",
                Content = responseMessage,
                Timestamp = DateTime.UtcNow
            });

            return new ChatMessageResponseDto
            {
                Message = responseMessage,
                SessionId = session.SessionId,
                BotPersona = session.BotPersona,
                Status = ChatResponseStatus.Success
            };
        }

        private async Task<string> GenerateAIResponseAsync(ChatSessionDto session)
        {
            var prompt = BuildContextualPrompt(session);
            var requestPayload = CreateGeminiRequestPayload(prompt);

            var jsonContent = JsonSerializer.Serialize(requestPayload);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var apiUrl = $"https://generativelanguage.googleapis.com/v1beta/models/{_settings.Model}:generateContent?key={_settings.ApiKey}";

            _logger.LogInformation("Sending chat request to Gemini API for session {SessionId}", session.SessionId);
            
            var response = await _httpClient.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var geminiResponse = JsonSerializer.Deserialize<JsonElement>(responseContent);

                if (geminiResponse.TryGetProperty("candidates", out var candidates) &&
                    candidates.GetArrayLength() > 0)
                {
                    var firstCandidate = candidates[0];
                    if (firstCandidate.TryGetProperty("content", out var contentProp) &&
                        contentProp.TryGetProperty("parts", out var parts) &&
                        parts.GetArrayLength() > 0)
                    {
                        var firstPart = parts[0];
                        if (firstPart.TryGetProperty("text", out var textProp))
                        {
                            return textProp.GetString() ?? "I'm having trouble generating a response right now.";
                        }
                    }
                }
            }

            _logger.LogWarning("Failed to get valid response from Gemini API. Status: {StatusCode}", response.StatusCode);
            return "I'm experiencing some technical difficulties. Please try asking your question again.";
        }

        private string BuildContextualPrompt(ChatSessionDto session)
        {
            var systemPrompt = GetSystemPromptForPersona(session.BotPersona);
            var conversationHistory = BuildConversationHistory(session);

            return $"{systemPrompt}\n\n{conversationHistory}";
        }

        private string GetSystemPromptForPersona(string persona)
        {
            return persona switch
            {
                nameof(BotPersona.NutritionCoach) => @"You are a certified Nutrition Coach and dietary expert. Your role is to:

• Provide evidence-based nutritional advice and meal planning guidance
• Help with dietary restrictions, food allergies, and special diets
• Offer practical tips for healthy eating habits and portion control
• Suggest nutritious recipes and meal prep strategies
• Explain nutritional concepts in an easy-to-understand way
• Support users in achieving their nutrition-related health goals

Be encouraging, knowledgeable, and practical in your responses. Always remind users to consult healthcare professionals for serious medical conditions. Keep responses conversational and supportive.",

                nameof(BotPersona.FitnessCoach) => @"You are a certified Fitness Coach and exercise specialist. Your role is to:

• Design personalized workout routines and training programs
• Provide guidance on proper exercise form and technique
• Help with fitness goal setting and progress tracking
• Offer advice on different types of training (strength, cardio, flexibility)
• Support motivation and help overcome fitness plateaus
• Explain exercise science concepts in simple terms

Be motivating, knowledgeable, and safety-focused in your responses. Always emphasize proper form and injury prevention. Keep responses energetic and encouraging.",

                _ => @"You are a helpful AI assistant for health and wellness. Be friendly, knowledgeable, and encouraging in your responses."
            };
        }

        private string BuildConversationHistory(ChatSessionDto session)
        {
            if (!session.Messages.Any())
                return "This is the start of the conversation.";

            var history = new StringBuilder("Recent conversation:\n");
            
            // Get last 10 messages for context
            var recentMessages = session.Messages.TakeLast(10);
            
            foreach (var message in recentMessages)
            {
                var role = message.Role == "user" ? "User" : "Assistant";
                history.AppendLine($"{role}: {message.Content}");
            }

            return history.ToString();
        }

        private object CreateGeminiRequestPayload(string prompt)
        {
            return new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new { text = prompt }
                        }
                    }
                },
                generationConfig = new
                {
                    temperature = _settings.Temperature,
                    topK = _settings.TopK,
                    topP = _settings.TopP,
                    maxOutputTokens = _settings.MaxTokens
                }
            };
        }

        private void TrimSessionHistory(ChatSessionDto session)
        {
            if (session.Messages.Count > MAX_HISTORY_MESSAGES)
            {
                var messagesToRemove = session.Messages.Count - MAX_HISTORY_MESSAGES;
                session.Messages.RemoveRange(0, messagesToRemove);
            }
        }

        private void UpdateSessionCache(ChatSessionDto session)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(SESSION_CACHE_MINUTES),
                SlidingExpiration = TimeSpan.FromMinutes(30),
                Priority = CacheItemPriority.High
            };

            _cache.Set(session.SessionId, session, cacheEntryOptions);
        }

        private void UpdateUserSessionsList(string userId, string sessionId)
        {
            var sessionListKey = $"user_sessions_{userId}";
            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(SESSION_CACHE_MINUTES),
                SlidingExpiration = TimeSpan.FromMinutes(30),
                Priority = CacheItemPriority.High
            };

            if (_cache.TryGetValue(sessionListKey, out List<string>? sessionIds))
            {
                if (!sessionIds!.Contains(sessionId))
                {
                    sessionIds.Add(sessionId);
                    _cache.Set(sessionListKey, sessionIds, cacheEntryOptions);
                }
            }
            else
            {
                _cache.Set(sessionListKey, new List<string> { sessionId }, cacheEntryOptions);
            }
        }
    }
} 