using graduationProject.DTOs;
using graduationProject.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;

namespace graduationProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ChatController : ControllerBase
    {
        private readonly IChatBotService _chatBotService;
        private readonly ILogger<ChatController> _logger;

        public ChatController(IChatBotService chatBotService, ILogger<ChatController> logger)
        {
            _chatBotService = chatBotService;
            _logger = logger;
        }

        /// <summary>
        /// Send a message to the chatbot and receive a complete response
        /// </summary>
        [HttpPost("message")]
        public async Task<ActionResult<ChatMessageResponseDto>> SendMessage([FromBody] ChatMessageRequestDto request)
        {
            try
            {
                var userId = GetAuthenticatedUserId();
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized("User authentication required");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _logger.LogInformation("Processing chat message for user {UserId}, IsFirstContact: {IsFirstContact}", 
                    userId, request.IsFirstContact);

                var response = await _chatBotService.SendMessageAsync(userId, request);
                
                if (response.Status == ChatResponseStatus.Error)
                {
                    return StatusCode(500, response);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing chat message");
                return StatusCode(500, new ChatMessageResponseDto 
                { 
                    Status = ChatResponseStatus.Error,
                    Error = "An unexpected error occurred"
                });
            }
        }

        /// <summary>
        /// Send a message to the chatbot and receive a streaming response
        /// </summary>
        [HttpPost("message/stream")]
        public async Task<IActionResult> SendMessageStream([FromBody] ChatMessageRequestDto request)
        {
            try
            {
                var userId = GetAuthenticatedUserId();
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized("User authentication required");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _logger.LogInformation("Processing streaming chat message for user {UserId}", userId);

                Response.Headers["Content-Type"] = "text/plain; charset=utf-8";
                Response.Headers["Cache-Control"] = "no-cache";
                Response.Headers["Connection"] = "keep-alive";

                await foreach (var chunk in _chatBotService.SendMessageStreamAsync(userId, request))
                {
                    var data = $"data: {chunk}\n\n";
                    var bytes = Encoding.UTF8.GetBytes(data);
                    
                    await Response.Body.WriteAsync(bytes, HttpContext.RequestAborted);
                    await Response.Body.FlushAsync(HttpContext.RequestAborted);
                }

                // Send completion signal
                var doneSignal = "data: [DONE]\n\n";
                var doneBytes = Encoding.UTF8.GetBytes(doneSignal);
                await Response.Body.WriteAsync(doneBytes, HttpContext.RequestAborted);
                await Response.Body.FlushAsync(HttpContext.RequestAborted);

                return new EmptyResult();
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Streaming request cancelled by client");
                return new EmptyResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in streaming chat");
                return StatusCode(500, "Streaming error occurred");
            }
        }

        /// <summary>
        /// Get chat session history for the authenticated user
        /// </summary>
        [HttpGet("session")]
        public async Task<ActionResult<ChatSessionDto>> GetChatSession([FromQuery] string? sessionId = null)
        {
            try
            {
                var userId = GetAuthenticatedUserId();
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized("User authentication required");
                }

                var session = await _chatBotService.GetChatSessionAsync(userId, sessionId);
                
                if (session == null)
                {
                    return NotFound("Chat session not found");
                }

                return Ok(session);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving chat session");
                return StatusCode(500, "Failed to retrieve chat session");
            }
        }

        /// <summary>
        /// Get all chat sessions for the authenticated user
        /// </summary>
        [HttpGet("sessions")]
        public async Task<ActionResult<List<ChatSessionDto>>> GetChatSessions()
        {
            try
            {
                var userId = GetAuthenticatedUserId();
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized("User authentication required");
                }

                var sessions = await _chatBotService.GetUserChatSessionsAsync(userId);
                return Ok(sessions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving chat sessions");
                return StatusCode(500, "Failed to retrieve chat sessions");
            }
        }

        /// <summary>
        /// Clear a specific chat session
        /// </summary>
        [HttpDelete("session/{sessionId}")]
        public async Task<IActionResult> ClearChatSession(string sessionId)
        {
            try
            {
                var userId = GetAuthenticatedUserId();
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized("User authentication required");
                }

                var result = await _chatBotService.ClearChatSessionAsync(userId, sessionId);
                
                if (result)
                {
                    return Ok(new { message = "Chat session cleared successfully" });
                }

                return NotFound("Chat session not found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error clearing chat session");
                return StatusCode(500, "Failed to clear chat session");
            }
        }

        /// <summary>
        /// Start a new chat session (first contact)
        /// </summary>
        [HttpPost("session/start")]
        public async Task<ActionResult<ChatMessageResponseDto>> StartChatSession()
        {
            try
            {
                var userId = GetAuthenticatedUserId();
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized("User authentication required");
                }

                var request = new ChatMessageRequestDto
                {
                    Message = "start",
                    IsFirstContact = true
                };

                var response = await _chatBotService.SendMessageAsync(userId, request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error starting chat session");
                return StatusCode(500, "Failed to start chat session");
            }
        }

        /// <summary>
        /// Health check endpoint for the chat service
        /// </summary>
        [HttpGet("health")]
        [AllowAnonymous]
        public IActionResult HealthCheck()
        {
            return Ok(new 
            { 
                status = "healthy", 
                service = "chatbot",
                timestamp = DateTime.UtcNow,
                version = "1.0.0"
            });
        }

        private string GetAuthenticatedUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
        }
    }
} 