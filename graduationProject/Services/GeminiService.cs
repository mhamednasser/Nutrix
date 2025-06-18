using graduationProject.Interfaces;
using graduationProject.Configurations;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Text.Json;
using System.Collections.Generic;

namespace graduationProject.Services
{
    public class GeminiService : IGeminiService
    {
        private readonly GeminiAISettings _geminiSettings;
        private readonly ILogger<GeminiService> _logger;
        private readonly HttpClient _httpClient;

        public GeminiService(IOptions<GeminiAISettings> geminiSettings, ILogger<GeminiService> logger, HttpClient httpClient)
        {
            _geminiSettings = geminiSettings.Value;
            _logger = logger;
            _httpClient = httpClient;
            
            // Configure timeout for faster responses
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        public async Task<string> DetectFoodAsync(IFormFile image)
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            
            try
            {
                // Validate image
                if (image == null || image.Length == 0)
                {
                    throw new ArgumentException("Image file is required");
                }

                _logger.LogInformation("Starting Gemini food detection for image: {FileName} ({Size} bytes)", 
                    image.FileName, image.Length);

                // Convert image to base64
                string base64Image;
                using (var memoryStream = new MemoryStream())
                {
                    await image.CopyToAsync(memoryStream);
                    var imageBytes = memoryStream.ToArray();
                    base64Image = Convert.ToBase64String(imageBytes);
                }

                // Create the prompt for food detection
                var prompt = CreateFoodDetectionPrompt();

                // Prepare request payload for Gemini REST API
                var requestPayload = new
                {
                    contents = new[]
                    {
                        new
                        {
                            parts = new object[]
                            {
                                new { text = prompt },
                                new
                                {
                                    inline_data = new
                                    {
                                        mime_type = image.ContentType,
                                        data = base64Image
                                    }
                                }
                            }
                        }
                    },
                    generationConfig = new
                    {
                        temperature = 0.1,  // Lower temperature for faster, more consistent responses
                        topK = 20,          // Reduced for faster processing
                        topP = 0.8,
                        maxOutputTokens = 1024  // Reduced from 2048 for faster responses
                    }
                };

                var jsonContent = JsonSerializer.Serialize(requestPayload);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Make request to Gemini API
                var apiUrl = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash-exp:generateContent?key={_geminiSettings.ApiKey}";
                
                _logger.LogInformation("Sending request to Gemini API...");
                var response = await _httpClient.PostAsync(apiUrl, content);

                stopwatch.Stop();
                _logger.LogInformation("Gemini API response received in {ElapsedMs}ms with status: {StatusCode}", 
                    stopwatch.ElapsedMilliseconds, response.StatusCode);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    _logger.LogInformation("Raw Gemini API response: {Response}", responseContent);
                    
                    var geminiResponse = JsonSerializer.Deserialize<JsonElement>(responseContent);

                    // Extract the text content from Gemini response
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
                                var generatedText = textProp.GetString();
                                _logger.LogInformation("Gemini generated text: {Text}", generatedText);
                                
                                // Clean and extract JSON from markdown if present
                                var cleanedJson = ExtractJsonFromMarkdown(generatedText ?? "");
                                _logger.LogInformation("Cleaned JSON: {Json}", cleanedJson);
                                
                                // Validate that it's proper JSON before returning
                                if (IsValidJson(cleanedJson))
                                {
                                    // Wrap the response in the expected format
                                    var wrappedResponse = new
                                    {
                                        status = "success",
                                        timestamp = DateTime.UtcNow,
                                        food_detection = JsonSerializer.Deserialize<JsonElement>(cleanedJson)
                                    };
                                    
                                    _logger.LogInformation("Gemini food detection completed successfully in {ElapsedMs}ms", 
                                        stopwatch.ElapsedMilliseconds);
                                    return JsonSerializer.Serialize(wrappedResponse);
                                }
                                else
                                {
                                    _logger.LogWarning("Gemini returned invalid JSON format: {Json}", cleanedJson);
                                }
                            }
                        }
                    }
                }

                _logger.LogWarning($"Gemini API returned status: {response.StatusCode}");
                var errorContent = await response.Content.ReadAsStringAsync();
                _logger.LogWarning($"Gemini API error response: {errorContent}");
                
                return CreateFallbackResponse();
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                _logger.LogError(ex, "Error in Gemini food detection after {ElapsedMs}ms", stopwatch.ElapsedMilliseconds);
                return CreateFallbackResponse();
            }
        }

        private string CreateFoodDetectionPrompt()
        {
            return @"
Analyze this food image and return ONLY a clean JSON response in this exact format:

{
  ""items"": [
    {
      ""food_name"": ""[Food Name]"",
      ""serving_size"": ""100g"",
      ""calories"": [number],
      ""macros"": {
        ""protein"": ""[number]g"",
        ""fat"": ""[number]g"",
        ""carbohydrates"": ""[number]g""
      }
    }
  ],
  ""source"": ""Gemini AI Analysis"",
  ""confidence_avg"": 0.85
}

Instructions:
1. Identify ALL distinct food items in the image
2. Provide nutritional data per 100g serving for each item
3. Use realistic nutritional values
4. Include confidence score (0.0-1.0)
5. Return ONLY valid JSON, no markdown formatting

Analyze the image:";
        }

        private string CreateFallbackResponse()
        {
                var fallbackResponse = new
                {
                    status = "success",
                    timestamp = DateTime.UtcNow,
                    food_detection = new
                    {
                        items = new object[0],
                        source = "Gemini AI Analysis - Error",
                        confidence_avg = 0.0
                    }
                };

                return JsonSerializer.Serialize(fallbackResponse);
        }

        private string ExtractJsonFromMarkdown(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "{}";

            // Remove markdown code blocks if present
            text = text.Trim();
            
            // Handle ```json ... ``` or ``` ... ``` blocks
            if (text.StartsWith("```"))
            {
                var lines = text.Split('\n');
                var jsonLines = new List<string>();
                bool inCodeBlock = false;
                
                foreach (var line in lines)
                {
                    if (line.Trim().StartsWith("```"))
                    {
                        inCodeBlock = !inCodeBlock;
                        continue;
                    }
                    
                    if (inCodeBlock)
                    {
                        jsonLines.Add(line);
                    }
                }
                
                text = string.Join('\n', jsonLines).Trim();
            }
            
            // Find JSON object boundaries
            int startIndex = text.IndexOf('{');
            if (startIndex >= 0)
            {
                int braceCount = 0;
                int endIndex = startIndex;
                
                for (int i = startIndex; i < text.Length; i++)
                {
                    if (text[i] == '{') braceCount++;
                    else if (text[i] == '}') braceCount--;
                    
                    if (braceCount == 0)
                    {
                        endIndex = i;
                        break;
                    }
                }
                
                if (braceCount == 0)
                {
                    text = text.Substring(startIndex, endIndex - startIndex + 1);
                }
            }
            
            return text;
        }

        private bool IsValidJson(string jsonString)
        {
            try
            {
                JsonSerializer.Deserialize<JsonElement>(jsonString);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
} 