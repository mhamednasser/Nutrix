using System.Text;
using System.Text.Json;
using graduationProject.Configurations;
using graduationProject.Interfaces;
using graduationProject.Models;
using Microsoft.Extensions.Options;

namespace graduationProject.Services
{
    public class GeminiPlanService : IPlanGenerationService
    {
        private readonly GeminiPlanSettings _geminiSettings;
        private readonly ILogger<GeminiPlanService> _logger;
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public GeminiPlanService(IOptions<GeminiPlanSettings> geminiSettings, ILogger<GeminiPlanService> logger, HttpClient httpClient)
        {
            _geminiSettings = geminiSettings.Value;
            _logger = logger;
            _httpClient = httpClient;
            
            // Configure for MAXIMUM SPEED
            _httpClient.Timeout = TimeSpan.FromSeconds(_geminiSettings.TimeoutSeconds);
            _baseUrl = $"https://generativelanguage.googleapis.com/v1beta/models/{_geminiSettings.Model}:generateContent";
            
            _logger.LogInformation("GeminiPlanService initialized with model: {Model}", _geminiSettings.Model);
        }

        public async Task<StructuredDietPlan> GenerateDietPlanAsync(UserProfile userProfile)
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            const int maxRetries = 3;
            
            for (int attempt = 1; attempt <= maxRetries; attempt++)
            {
                try
                {
                    _logger.LogInformation("Starting SPEED-OPTIMIZED diet plan generation for user {UserId} (Attempt {Attempt}/{MaxRetries})", userProfile.Id, attempt, maxRetries);

                    var prompt = GenerateDietPlanPrompt(userProfile);
                    var jsonSchema = GetDietPlanJsonSchema();
                    
                    var response = await CallGeminiApiAsync(prompt, jsonSchema, "diet_plan");
                    
                    // Validate and normalize the response
                    var normalizedResponse = await NormalizeAndValidateDietPlan(response);
                    
                    if (!string.IsNullOrEmpty(normalizedResponse))
                    {
                        stopwatch.Stop();
                        _logger.LogInformation("Diet plan generated successfully in {ElapsedMs}ms using Gemini Flash 2.5", stopwatch.ElapsedMilliseconds);

                        return new StructuredDietPlan
                        {
                            UserProfileId = userProfile.Id,
                            PlanJson = normalizedResponse,
                        };
                    }
                    
                    _logger.LogWarning("Attempt {Attempt} failed validation, retrying...", attempt);
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Attempt {Attempt} failed with error: {Error}", attempt, ex.Message);
                    
                    if (attempt == maxRetries)
                    {
                        stopwatch.Stop();
                        _logger.LogError(ex, "Failed to generate diet plan after {MaxRetries} attempts in {ElapsedMs}ms", maxRetries, stopwatch.ElapsedMilliseconds);
                        throw;
                    }
                    
                    // Wait before retry (exponential backoff)
                    await Task.Delay(1000 * attempt);
                }
            }
            
            throw new InvalidOperationException("Failed to generate a valid diet plan after maximum retries.");
        }

        public async Task<StructuredWorkoutPlan> GenerateWorkoutPlanAsync(UserProfile userProfile)
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            
            try
            {
                _logger.LogInformation("Starting SPEED-OPTIMIZED workout plan generation for user {UserId}", userProfile.Id);

                var prompt = GenerateWorkoutPlanPrompt(userProfile);
                var jsonSchema = GetWorkoutPlanJsonSchema();
                
                var response = await CallGeminiApiAsync(prompt, jsonSchema, "workout_plan");
                
                stopwatch.Stop();
                _logger.LogInformation("Workout plan generated in {ElapsedMs}ms using Gemini Flash 2.5", stopwatch.ElapsedMilliseconds);

                return new StructuredWorkoutPlan
                {
                    UserProfileId = userProfile.Id,
                    PlanJson = response,
                };
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                _logger.LogError(ex, "Failed to generate workout plan in {ElapsedMs}ms", stopwatch.ElapsedMilliseconds);
                throw;
            }
        }

        private async Task<string> CallGeminiApiAsync(string prompt, object jsonSchema, string schemaName)
        {
            var requestPayload = new
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
                    temperature = _geminiSettings.Temperature,
                    topK = _geminiSettings.TopK,
                    topP = _geminiSettings.TopP,
                    maxOutputTokens = _geminiSettings.MaxTokens,
                    responseMimeType = "application/json",
                    responseSchema = jsonSchema
                }
            };

            var jsonContent = JsonSerializer.Serialize(requestPayload);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var apiUrl = $"{_baseUrl}?key={_geminiSettings.ApiKey}";
            
            _logger.LogInformation("Sending SPEED request to Gemini Flash 2.5...");
            var response = await _httpClient.PostAsync(apiUrl, content);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                _logger.LogError("Gemini API error: {StatusCode} - {Error}", response.StatusCode, errorContent);
                throw new HttpRequestException($"Gemini API error: {response.StatusCode}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var geminiResponse = JsonSerializer.Deserialize<JsonElement>(responseContent);

            // Extract the generated content
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
                        _logger.LogInformation("Gemini Flash 2.5 generated structured response successfully");
                        return generatedText ?? "{}";
                    }
                }
            }

            _logger.LogWarning("Unexpected Gemini response structure");
            return "{}";
        }

        private object GetDietPlanJsonSchema()
        {
            return new
            {
                type = "object",
                properties = new
                {
                    duration = new { type = "string" },
                    goal = new { type = "string" },
                    daily_plans = new
                    {
                        type = "array",
                        items = new
                        {
                            type = "object",
                            properties = new
                            {
                                day = new { type = "string" },
                                meals = new
                                {
                                    type = "object",
                                    properties = new
                                    {
                                        breakfast = new
                                        {
                                            type = "object",
                                            properties = new
                                            {
                                                main = new
                                                {
                                                    type = "object",
                                                    properties = new
                                                    {
                                                        name = new { type = "string" },
                                                        portion = new { type = "string" },
                                                        calories = new { type = "number" },
                                                        macronutrients = new
                                                        {
                                                            type = "object",
                                                            properties = new
                                                            {
                                                                carbs = new { type = "number" },
                                                                protein = new { type = "number" },
                                                                fat = new { type = "number" }
                                                            },
                                                            required = new[] { "carbs", "protein", "fat" }
                                                        }
                                                    },
                                                    required = new[] { "name", "portion", "calories", "macronutrients" }
                                                },
                                                alternatives = new
                                                {
                                                    type = "array",
                                                    items = new
                                                    {
                                                        type = "object",
                                                        properties = new
                                                        {
                                                            name = new { type = "string" },
                                                            portion = new { type = "string" },
                                                            calories = new { type = "number" },
                                                            macronutrients = new
                                                            {
                                                                type = "object",
                                                                properties = new
                                                                {
                                                                    carbs = new { type = "number" },
                                                                    protein = new { type = "number" },
                                                                    fat = new { type = "number" }
                                                                },
                                                                required = new[] { "carbs", "protein", "fat" }
                                                            }
                                                        },
                                                        required = new[] { "name", "portion", "calories", "macronutrients" }
                                                    }
                                                }
                                            },
                                            required = new[] { "main", "alternatives" }
                                        },
                                        lunch = new
                                        {
                                            type = "object",
                                            properties = new
                                            {
                                                main = new
                                                {
                                                    type = "object",
                                                    properties = new
                                                    {
                                                        name = new { type = "string" },
                                                        portion = new { type = "string" },
                                                        calories = new { type = "number" },
                                                        macronutrients = new
                                                        {
                                                            type = "object",
                                                            properties = new
                                                            {
                                                                carbs = new { type = "number" },
                                                                protein = new { type = "number" },
                                                                fat = new { type = "number" }
                                                            },
                                                            required = new[] { "carbs", "protein", "fat" }
                                                        }
                                                    },
                                                    required = new[] { "name", "portion", "calories", "macronutrients" }
                                                },
                                                alternatives = new
                                                {
                                                    type = "array",
                                                    items = new
                                                    {
                                                        type = "object",
                                                        properties = new
                                                        {
                                                            name = new { type = "string" },
                                                            portion = new { type = "string" },
                                                            calories = new { type = "number" },
                                                            macronutrients = new
                                                            {
                                                                type = "object",
                                                                properties = new
                                                                {
                                                                    carbs = new { type = "number" },
                                                                    protein = new { type = "number" },
                                                                    fat = new { type = "number" }
                                                                },
                                                                required = new[] { "carbs", "protein", "fat" }
                                                            }
                                                        },
                                                        required = new[] { "name", "portion", "calories", "macronutrients" }
                                                    }
                                                }
                                            },
                                            required = new[] { "main", "alternatives" }
                                        },
                                        dinner = new
                                        {
                                            type = "object",
                                            properties = new
                                            {
                                                main = new
                                                {
                                                    type = "object",
                                                    properties = new
                                                    {
                                                        name = new { type = "string" },
                                                        portion = new { type = "string" },
                                                        calories = new { type = "number" },
                                                        macronutrients = new
                                                        {
                                                            type = "object",
                                                            properties = new
                                                            {
                                                                carbs = new { type = "number" },
                                                                protein = new { type = "number" },
                                                                fat = new { type = "number" }
                                                            },
                                                            required = new[] { "carbs", "protein", "fat" }
                                                        }
                                                    },
                                                    required = new[] { "name", "portion", "calories", "macronutrients" }
                                                },
                                                alternatives = new
                                                {
                                                    type = "array",
                                                    items = new
                                                    {
                                                        type = "object",
                                                        properties = new
                                                        {
                                                            name = new { type = "string" },
                                                            portion = new { type = "string" },
                                                            calories = new { type = "number" },
                                                            macronutrients = new
                                                            {
                                                                type = "object",
                                                                properties = new
                                                                {
                                                                    carbs = new { type = "number" },
                                                                    protein = new { type = "number" },
                                                                    fat = new { type = "number" }
                                                                },
                                                                required = new[] { "carbs", "protein", "fat" }
                                                            }
                                                        },
                                                        required = new[] { "name", "portion", "calories", "macronutrients" }
                                                    }
                                                }
                                            },
                                            required = new[] { "main", "alternatives" }
                                        }
                                    },
                                    required = new[] { "breakfast", "lunch", "dinner" }
                                }
                            },
                            required = new[] { "day", "meals" }
                        }
                    },
                    notes = new
                    {
                        type = "array",
                        items = new { type = "string" }
                    }
                },
                required = new[] { "duration", "goal", "daily_plans", "notes" }
            };
        }

        private object GetWorkoutPlanJsonSchema()
        {
            return new
            {
                type = "object",
                properties = new
                {
                    duration = new { type = "string" },
                    goal = new { type = "string" },
                    daily_plans = new
                    {
                        type = "array",
                        items = new
                        {
                            type = "object",
                            properties = new
                            {
                                day = new { type = "string" },
                                focus = new { type = "string" },
                                exercises = new
                                {
                                    type = "array",
                                    items = new
                                    {
                                        type = "object",
                                        properties = new
                                        {
                                            name = new { type = "string" },
                                            muscle_group = new { type = "string" },
                                            sets = new { type = "integer" },
                                            reps = new { type = "string" },
                                            rest_between_sets = new { type = "string" },
                                            intensity = new { type = "string" },
                                            notes = new
                                            {
                                                type = "array",
                                                items = new { type = "string" }
                                            }
                                        },
                                        required = new[] { "name", "muscle_group", "sets", "reps", "rest_between_sets", "intensity", "notes" }
                                    }
                                }
                            },
                            required = new[] { "day", "focus", "exercises" }
                        }
                    },
                    rest_days = new
                    {
                        type = "array",
                        items = new { type = "string" }
                    },
                    notes = new
                    {
                        type = "array",
                        items = new { type = "string" }
                    }
                },
                required = new[] { "duration", "goal", "daily_plans", "rest_days", "notes" }
            };
        }

        private string GenerateDietPlanPrompt(UserProfile userProfile)
        {
            return $"""
The user is an {userProfile.Age}-year-old {userProfile.Gender} from Egypt, with a height of {userProfile.Height} meters and a weight of {userProfile.Weight} kg.
Their fitness goal is {userProfile.Goal}.
They prefer a {userProfile.PreferredDiet} diet.
They work out {userProfile.WeeklyWorkoutDays} days a week, for {userProfile.WorkoutDuration}.
They have the following dietary restrictions: {userProfile.DietaryRestrictions}.
They have the following medical conditions: {userProfile.MedicalConditions}.
The plan should use traditional, locally available ingredients and reflect cultural preferences (Egyptian cuisine).
Ensure the plan is nutritionally balanced, with a focus on whole foods, lean proteins, complex carbs, and healthy fats.
Avoid processed foods, sugary drinks, and excessive amounts of refined carbs.
Include a variety of vegetables, fruits, and whole grains in each meal.
Create a personalized diet plan with the following structure:
- Duration: "1 week" 
- Goal: Based on user's fitness goal
- Daily plans: Array of 7 days (Saturday, Sunday, Monday, Tuesday, Wednesday, Thursday, Friday)
- Each day should have: day name and meals object
- Each meals object should have: breakfast, lunch, and dinner
- Each meal should have: main dish and alternatives array (at least 1 alternative, max 3)
- Each dish should have: name, portion size, calories (number), and macronutrients (carbs, protein, fat in grams as numbers)
- Notes: Array of helpful dietary advice and tips
Please provide a complete, structured response following the exact JSON schema.
""";
        }

        private string GenerateWorkoutPlanPrompt(UserProfile userProfile)
        {
            return $"""
The user is an {userProfile.Age}-year-old {userProfile.Gender} with a height of {userProfile.Height} meters and a weight of {userProfile.Weight} kg.
Their fitness level is {userProfile.FitnessLevel}, and they aim to {userProfile.Goal}.
They work out {userProfile.WeeklyWorkoutDays} days a week, for {userProfile.WorkoutDuration} per session.
The plan should include exercises for strength, cardio, and flexibility, with rest days included.
Include at least 4-6 exercises per workout day, targeting different muscle groups.
Use specific exercise names like Fly Machine, Lat Pulldown, Bench Press, Squats, etc., based on the user's goals and fitness level.
Ensure the plan is tailored to their fitness level and goals.
The plan must cover one full week (7 days) with detailed daily plans, including exercises, sets, reps, rest times, and intensity levels.
Include rest days and additional notes for each day.
Please provide a complete, structured response following the exact JSON schema.
""";
        }

        private async Task<string> NormalizeAndValidateDietPlan(string response)
        {
            try
            {
                // First, try to repair/clean the JSON if it's malformed
                var cleanedJson = RepairJsonString(response);
                
                var jsonDoc = JsonDocument.Parse(cleanedJson);
                var root = jsonDoc.RootElement;
                
                // Create a normalized structure
                var normalizedPlan = new
                {
                    duration = GetStringProperty(root, "duration") ?? "1 week",
                    goal = GetStringProperty(root, "goal") ?? "Balanced nutrition",
                    daily_plans = NormalizeDailyPlans(root),
                    notes = NormalizeNotes(root)
                };
                
                // Validate the normalized plan has minimum required structure
                if (normalizedPlan.daily_plans.Count == 0)
                {
                    _logger.LogWarning("Normalized plan has no daily plans");
                    return string.Empty;
                }
                
                var normalizedJson = JsonSerializer.Serialize(normalizedPlan, new JsonSerializerOptions 
                { 
                    WriteIndented = false 
                });
                
                _logger.LogInformation("Successfully normalized and validated diet plan");
                return normalizedJson;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to normalize diet plan response: {Response}", response?.Substring(0, Math.Min(200, response?.Length ?? 0)));
                return string.Empty;
            }
        }
        
        private string RepairJsonString(string json)
        {
            if (string.IsNullOrEmpty(json))
                return "{}";
                
            // Test if JSON is already valid WITHOUT throwing exceptions
            bool isValidJson = false;
            try
            {
                using var doc = JsonDocument.Parse(json);
                isValidJson = true;
            }
            catch
            {
                isValidJson = false;
            }
            
            if (isValidJson)
                return json;
            
            // JSON is malformed, try to repair it
            _logger.LogInformation("Attempting to repair malformed JSON...");
            
            // Remove any trailing incomplete parts
            json = json.Trim();
            
            // Count open/close braces and brackets to fix structure
            int openBraces = 0;
            int openBrackets = 0;
            bool inString = false;
            bool escaped = false;
            
            var repairedJson = new StringBuilder();
            
            for (int i = 0; i < json.Length; i++)
            {
                char c = json[i];
                
                if (escaped)
                {
                    escaped = false;
                    repairedJson.Append(c);
                    continue;
                }
                
                if (c == '\\' && inString)
                {
                    escaped = true;
                    repairedJson.Append(c);
                    continue;
                }
                
                if (c == '"' && !escaped)
                {
                    inString = !inString;
                    repairedJson.Append(c);
                    continue;
                }
                
                if (!inString)
                {
                    if (c == '{')
                        openBraces++;
                    else if (c == '}')
                        openBraces--;
                    else if (c == '[')
                        openBrackets++;
                    else if (c == ']')
                        openBrackets--;
                }
                
                repairedJson.Append(c);
            }
            
            // Close any unclosed strings
            if (inString)
            {
                repairedJson.Append('"');
            }
            
            // Close any unclosed brackets/braces
            while (openBrackets > 0)
            {
                repairedJson.Append(']');
                openBrackets--;
            }
            
            while (openBraces > 0)
            {
                repairedJson.Append('}');
                openBraces--;
            }
            
            var repairedResult = repairedJson.ToString();
            
            // Test if the repaired JSON is valid
            try
            {
                using var doc = JsonDocument.Parse(repairedResult);
                _logger.LogInformation("Successfully repaired malformed JSON");
                return repairedResult;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Could not repair malformed JSON, using fallback. Repair attempt: {RepairedJson}", repairedResult?.Substring(0, Math.Min(200, repairedResult?.Length ?? 0)));
                return CreateFallbackJsonPlan();
            }
        }
        
        private string CreateFallbackJsonPlan()
        {
            var fallbackPlan = new
            {
                duration = "1 week",
                goal = "Balanced Egyptian nutrition plan",
                daily_plans = new[]
                {
                    CreateFallbackDay("Saturday"),
                    CreateFallbackDay("Sunday"), 
                    CreateFallbackDay("Monday"),
                    CreateFallbackDay("Tuesday"),
                    CreateFallbackDay("Wednesday"),
                    CreateFallbackDay("Thursday"),
                    CreateFallbackDay("Friday")
                },
                notes = new[]
                {
                    "Drink at least 8 glasses of water daily",
                    "Use fresh, locally available Egyptian ingredients",
                    "Adjust portions based on your activity level",
                    "This is a fallback plan - consider regenerating for personalized content"
                }
            };
            
            return JsonSerializer.Serialize(fallbackPlan);
        }
        
        private object CreateFallbackDay(string dayName)
        {
            return new
            {
                day = dayName,
                meals = new
                {
                    breakfast = new
                    {
                        main = new
                        {
                            name = "Egyptian Foul with Bread",
                            portion = "1 bowl with 2 pieces pita",
                            calories = 350,
                            macronutrients = new { carbs = 45.0, protein = 15.0, fat = 12.0 }
                        },
                        alternatives = new[]
                        {
                            new
                            {
                                name = "Scrambled Eggs with Cheese",
                                portion = "2 eggs with white cheese",
                                calories = 320,
                                macronutrients = new { carbs = 5.0, protein = 20.0, fat = 15.0 }
                            }
                        }
                    },
                    lunch = new
                    {
                        main = new
                        {
                            name = "Grilled Chicken with Rice",
                            portion = "150g chicken with 1 cup rice",
                            calories = 450,
                            macronutrients = new { carbs = 45.0, protein = 35.0, fat = 8.0 }
                        },
                        alternatives = new[]
                        {
                            new
                            {
                                name = "Lentil Soup with Bread",
                                portion = "2 cups soup with bread",
                                calories = 400,
                                macronutrients = new { carbs = 60.0, protein = 18.0, fat = 8.0 }
                            }
                        }
                    },
                    dinner = new
                    {
                        main = new
                        {
                            name = "Grilled Fish with Vegetables",
                            portion = "150g fish with mixed vegetables",
                            calories = 300,
                            macronutrients = new { carbs = 15.0, protein = 30.0, fat = 10.0 }
                        },
                        alternatives = new[]
                        {
                            new
                            {
                                name = "Vegetable Stew with Bread",
                                portion = "1 large bowl with pita",
                                calories = 280,
                                macronutrients = new { carbs = 40.0, protein = 12.0, fat = 8.0 }
                            }
                        }
                    }
                }
            };
        }
        
        private string? GetStringProperty(JsonElement element, string propertyName)
        {
            return element.TryGetProperty(propertyName, out var prop) && prop.ValueKind == JsonValueKind.String 
                ? prop.GetString() 
                : null;
        }
        
        private List<object> NormalizeDailyPlans(JsonElement root)
        {
            var dailyPlans = new List<object>();
            var daysOfWeek = new[] { "Saturday", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            
            if (root.TryGetProperty("daily_plans", out var plansArray) && plansArray.ValueKind == JsonValueKind.Array)
            {
                int dayIndex = 0;
                foreach (var planElement in plansArray.EnumerateArray())
                {
                    if (dayIndex >= daysOfWeek.Length) break;
                    
                    var dayName = GetStringProperty(planElement, "day") ?? daysOfWeek[dayIndex];
                    var meals = NormalizeMeals(planElement);
                    
                    dailyPlans.Add(new
                    {
                        day = dayName,
                        meals = meals
                    });
                    
                    dayIndex++;
                }
            }
            
            // Ensure we have at least 7 days
            while (dailyPlans.Count < 7)
            {
                var dayName = daysOfWeek[dailyPlans.Count];
                dailyPlans.Add(new
                {
                    day = dayName,
                    meals = CreateDefaultMeals()
                });
            }
            
            return dailyPlans;
        }
        
        private object NormalizeMeals(JsonElement dayElement)
        {
            var defaultMeal = CreateDefaultMeal();
            
            if (dayElement.TryGetProperty("meals", out var mealsElement))
            {
                return new
                {
                    breakfast = NormalizeMeal(mealsElement, "breakfast") ?? defaultMeal,
                    lunch = NormalizeMeal(mealsElement, "lunch") ?? defaultMeal,
                    dinner = NormalizeMeal(mealsElement, "dinner") ?? defaultMeal
                };
            }
            
            return CreateDefaultMeals();
        }
        
        private object? NormalizeMeal(JsonElement mealsElement, string mealType)
        {
            if (mealsElement.TryGetProperty(mealType, out var mealElement))
            {
                var main = NormalizeDish(mealElement, "main") ?? CreateDefaultDish($"Egyptian {mealType}");
                var alternatives = NormalizeAlternatives(mealElement);
                
                return new
                {
                    main = main,
                    alternatives = alternatives.Count > 0 ? alternatives : new List<object> { CreateDefaultDish($"Alternative {mealType}") }
                };
            }
            
            return null;
        }
        
        private object? NormalizeDish(JsonElement mealElement, string dishType)
        {
            if (mealElement.TryGetProperty(dishType, out var dishElement))
            {
                return new
                {
                    name = GetStringProperty(dishElement, "name") ?? "Egyptian Dish",
                    portion = GetStringProperty(dishElement, "portion") ?? "1 serving",
                    calories = GetNumberProperty(dishElement, "calories") ?? 300,
                    macronutrients = NormalizeMacronutrients(dishElement)
                };
            }
            
            return null;
        }
        
        private double? GetNumberProperty(JsonElement element, string propertyName)
        {
            if (element.TryGetProperty(propertyName, out var prop))
            {
                if (prop.ValueKind == JsonValueKind.Number)
                    return prop.GetDouble();
                if (prop.ValueKind == JsonValueKind.String && double.TryParse(prop.GetString(), out var parsed))
                    return parsed;
            }
            return null;
        }
        
        private object NormalizeMacronutrients(JsonElement dishElement)
        {
            var defaultMacros = new { carbs = 30.0, protein = 20.0, fat = 10.0 };
            
            if (dishElement.TryGetProperty("macronutrients", out var macrosElement))
            {
                return new
                {
                    carbs = GetNumberProperty(macrosElement, "carbs") ?? defaultMacros.carbs,
                    protein = GetNumberProperty(macrosElement, "protein") ?? defaultMacros.protein,
                    fat = GetNumberProperty(macrosElement, "fat") ?? defaultMacros.fat
                };
            }
            
            return defaultMacros;
        }
        
        private List<object> NormalizeAlternatives(JsonElement mealElement)
        {
            var alternatives = new List<object>();
            
            if (mealElement.TryGetProperty("alternatives", out var altArray) && altArray.ValueKind == JsonValueKind.Array)
            {
                foreach (var altElement in altArray.EnumerateArray())
                {
                    var dish = new
                    {
                        name = GetStringProperty(altElement, "name") ?? "Egyptian Alternative",
                        portion = GetStringProperty(altElement, "portion") ?? "1 serving",
                        calories = GetNumberProperty(altElement, "calories") ?? 300,
                        macronutrients = NormalizeMacronutrients(altElement)
                    };
                    alternatives.Add(dish);
                }
            }
            
            return alternatives;
        }
        
        private List<string> NormalizeNotes(JsonElement root)
        {
            var notes = new List<string>();
            
            if (root.TryGetProperty("notes", out var notesArray) && notesArray.ValueKind == JsonValueKind.Array)
            {
                foreach (var noteElement in notesArray.EnumerateArray())
                {
                    if (noteElement.ValueKind == JsonValueKind.String)
                    {
                        var note = noteElement.GetString();
                        if (!string.IsNullOrWhiteSpace(note))
                            notes.Add(note);
                    }
                }
            }
            
            // Ensure we have at least some basic notes
            if (notes.Count == 0)
            {
                notes.AddRange(new[]
                {
                    "Drink at least 8 glasses of water daily",
                    "Use fresh, locally available Egyptian ingredients",
                    "Adjust portions based on your activity level"
                });
            }
            
            return notes;
        }
        
        private object CreateDefaultMeals()
        {
            return new
            {
                breakfast = CreateDefaultMeal(),
                lunch = CreateDefaultMeal(),
                dinner = CreateDefaultMeal()
            };
        }
        
        private object CreateDefaultMeal()
        {
            return new
            {
                main = CreateDefaultDish("Egyptian Traditional Dish"),
                alternatives = new List<object> { CreateDefaultDish("Egyptian Alternative") }
            };
        }
        
        private object CreateDefaultDish(string name)
        {
            return new
            {
                name = name,
                portion = "1 serving",
                calories = 300,
                macronutrients = new
                {
                    carbs = 30.0,
                    protein = 20.0,
                    fat = 10.0
                }
            };
        }
    }
} 