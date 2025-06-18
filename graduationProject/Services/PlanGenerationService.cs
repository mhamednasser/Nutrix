using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using graduationProject.DTOs;
using graduationProject.Interfaces;
using graduationProject.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OpenAI.Chat;

namespace graduationProject.Services
{
    public class PlanGenerationService : IPlanGenerationService
    {
        private readonly HttpClient _httpClient;
        private readonly string _openAiApiKey;
        private readonly ILogger<PlanGenerationService> _logger;
        private readonly ChatClient _chatClient;


        private static readonly ChatResponseFormat DietPlanResponseFormat = ChatResponseFormat.CreateJsonSchemaFormat(
jsonSchemaIsStrict: true,
jsonSchemaFormatName: "diet_plan",
jsonSchema: BinaryData.FromBytes("""
{
    "$schema": "https://json-schema.org/draft/2019-09/schema",
    "title": "diet plan",
    "description": "description of a diet plan for a week, three meals a day with main dish and alternatives, each with macronutrients",
    "type": "object",
    "additionalProperties": false,
    "required": [
        "duration",
        "goal",
        "daily_plans",
        "notes"
    ],
    "properties": {
        "duration": {
            "description": "The duration of the diet plan.",
            "type": "string"
        },
        "goal": {
            "description": "The goal of the diet plan (e.g., weight loss, muscle gain).",
            "type": "string"
        },
        "daily_plans": {
            "description": "Daily meal plans for the week.",
            "type": "array",
            "items": {
                "$ref": "#/$defs/day"
            }
        },
        "notes": {
            "description": "Additional notes or comments.",
            "type": "array",
            "items": {
                "type": "string"
            }
        }
    },
    "$defs": {
        "day": {
            "type": "object",
            "additionalProperties": false,
            "required": [
                "day",
                "meals"
            ],
            "properties": {
                "day": {
                    "description": "The day of the week (e.g., Saturday).",
                    "type": "string"
                },
                "meals": {
                    "type": "object",
                    "additionalProperties": false,
                    "required": [
                        "breakfast",
                        "lunch",
                        "dinner"
                    ],
                    "properties": {
                        "breakfast": {
                            "$ref": "#/$defs/meal"
                        },
                        "lunch": {
                            "$ref": "#/$defs/meal"
                        },
                        "dinner": {
                            "$ref": "#/$defs/meal"
                        }
                    }
                }
            }
        },
        "meal": {
            "description": "meal with a main dish and at least one alternative",
            "type": "object",
            "additionalProperties": false,
            "required": [
                "main",
                "alternatives"
            ],
            "properties": {
                "main": {
                    "$ref": "#/$defs/dish"
                },
                "alternatives": {
                    "description": "an array of alternative dishes, there must be at least one alternative and at most three",
                    "type": "array",
                    "items": {
                        "$ref": "#/$defs/dish"
                    }
                }
            }
        },
        "dish": {
            "description": "name of a dish with its portion and macronutrients",
            "type": "object",
            "additionalProperties": false,
            "required": [
                "name",
                "portion",
                "calories",
                "macronutrients"
            ],
            "properties": {
                "name": {
                    "description": "english name of the dish",
                    "type": "string"
                },
                "portion": {
                    "description": "the serving size of the dish in free text units, e.g. '1 slice' etc.",
                    "type": "string"
                },
                "calories": {
                    "description": "total calories in the meal in kcal",
                    "type": "number"
                },
                "macronutrients": {
                    "description": "macronutrients in grams",
                    "type": "object",
                    "additionalProperties": false,
                    "required": [
                        "carbs",
                        "protein",
                        "fat"
                    ],
                    "properties": {
                        "carbs": {
                            "description": "total carbohydrates in grams",
                            "type": "number"
                        },
                        "protein": {
                            "description": "total protein in grams",
                            "type": "number"
                        },
                        "fat": {
                            "description": "total fat in grams",
                            "type": "number"
                        }
                    }
                }
            }
        }
    }
}
"""u8.ToArray())
);

        //        // Function schema for the diet plan
        //        private static readonly string DietPlanFunctionSchema = @"
        //{
        //  ""name"": ""generate_diet_plan"",
        //  ""description"": ""Generates a structured diet plan based on user input."",
        //  ""parameters"": {
        //    ""type"": ""object"",
        //    ""properties"": {
        //      ""Duration"": {
        //        ""type"": ""string"",
        //        ""description"": ""The duration of the diet plan.""
        //      },
        //      ""DailyCalories"": {
        //        ""type"": ""integer"",
        //        ""description"": ""The total daily calorie target.""
        //      },
        //      ""MacronutrientDistribution"": {
        //        ""type"": ""string"",
        //        ""description"": ""The macronutrient distribution (e.g., 40% carbs, 30% protein, 30% fat).""
        //      },
        //      ""WeeklyPlans"": {
        //        ""type"": ""array"",
        //        ""items"": {
        //          ""type"": ""object"",
        //          ""properties"": {
        //            ""WeekNumber"": {
        //              ""type"": ""integer"",
        //              ""description"": ""The week number.""
        //            },
        //            ""DailyPlans"": {
        //              ""type"": ""array"",
        //              ""items"": {
        //                ""type"": ""object"",
        //                ""properties"": {
        //                  ""Day"": {
        //                    ""type"": ""string"",
        //                    ""description"": ""The day of the week (e.g., Monday).""
        //                  },
        //                  ""Meals"": {
        //                    ""type"": ""array"",
        //                    ""items"": {
        //                      ""type"": ""object"",
        //                      ""properties"": {
        //                        ""Name"": {
        //                          ""type"": ""string"",
        //                          ""description"": ""The name of the meal (e.g., Breakfast).""
        //                        },
        //                        ""Items"": {
        //                          ""type"": ""array"",
        //                          ""items"": {
        //                            ""type"": ""object"",
        //                            ""properties"": {
        //                              ""Name"": {
        //                                ""type"": ""string"",
        //                                ""description"": ""The name of the food item.""
        //                              },
        //                              ""PortionSize"": {
        //                                ""type"": ""string"",
        //                                ""description"": ""The portion size of the food item.""
        //                              },
        //                              ""Calories"": {
        //                                ""type"": ""integer"",
        //                                ""description"": ""The calorie count of the food item.""
        //                              },
        //                              ""Macronutrients"": {
        //                                ""type"": ""object"",
        //                                ""properties"": {
        //                                  ""Carbs"": {
        //                                    ""type"": ""string"",
        //                                    ""description"": ""The carbohydrate content.""
        //                                  },
        //                                  ""Protein"": {
        //                                    ""type"": ""string"",
        //                                    ""description"": ""The protein content.""
        //                                  },
        //                                  ""Fat"": {
        //                                    ""type"": ""string"",
        //                                    ""description"": ""The fat content.""
        //                                  }
        //                                }
        //                              },
        //                              ""Alternatives"": {
        //                                ""type"": ""array"",
        //                                ""items"": {
        //                                  ""type"": ""object"",
        //                                  ""properties"": {
        //                                    ""Name"": {
        //                                      ""type"": ""string"",
        //                                      ""description"": ""The name of the alternative food item.""
        //                                    },
        //                                    ""PortionSize"": {
        //                                      ""type"": ""string"",
        //                                      ""description"": ""The portion size of the alternative food item.""
        //                                    },
        //                                    ""Calories"": {
        //                                      ""type"": ""integer"",
        //                                      ""description"": ""The calorie count of the alternative food item.""
        //                                    },
        //                                    ""Macronutrients"": {
        //                                      ""type"": ""object"",
        //                                      ""properties"": {
        //                                        ""Carbs"": {
        //                                          ""type"": ""string"",
        //                                          ""description"": ""The carbohydrate content of the alternative food item.""
        //                                        },
        //                                        ""Protein"": {
        //                                          ""type"": ""string"",
        //                                          ""description"": ""The protein content of the alternative food item.""
        //                                        },
        //                                        ""Fat"": {
        //                                          ""type"": ""string"",
        //                                          ""description"": ""The fat content of the alternative food item.""
        //                                        }
        //                                      }
        //                                    }
        //                                  }
        //                                }
        //                              }
        //                            }
        //                          }
        //                        }
        //                      }
        //                    }
        //                  }
        //                }
        //              }
        //            }
        //          }
        //        }
        //      },
        //      ""ShoppingList"": {
        //        ""type"": ""array"",
        //        ""items"": {
        //          ""type"": ""object"",
        //          ""properties"": {
        //            ""Item"": {
        //              ""type"": ""string"",
        //              ""description"": ""The name of the shopping list item.""
        //            },
        //            ""Quantity"": {
        //              ""type"": ""string"",
        //              ""description"": ""The quantity of the shopping list item.""
        //            }
        //          }
        //        }
        //      },
        //      ""HydrationPlan"": {
        //        ""type"": ""array"",
        //        ""items"": {
        //          ""type"": ""object"",
        //          ""properties"": {
        //            ""Time"": {
        //              ""type"": ""string"",
        //              ""description"": ""The time for hydration (e.g., Morning).""
        //            },
        //            ""Instruction"": {
        //              ""type"": ""string"",
        //              ""description"": ""The hydration instruction (e.g., Drink a glass of water).""
        //            }
        //          }
        //        }
        //      },
        //      ""ProgressTracking"": {
        //        ""type"": ""array"",
        //        ""items"": {
        //          ""type"": ""object"",
        //          ""properties"": {
        //            ""Instruction"": {
        //              ""type"": ""string"",
        //              ""description"": ""The progress tracking instruction (e.g., Track weight daily).""
        //            }
        //          }
        //        }
        //      },
        //      ""Notes"": {
        //        ""type"": ""array"",
        //        ""items"": {
        //          ""type"": ""string"",
        //          ""description"": ""Additional notes or comments.""
        //        }
        //      }
        //    },
        //    ""required"": [""Duration"", ""DailyCalories"", ""MacronutrientDistribution"", ""WeeklyPlans"", ""ShoppingList"", ""HydrationPlan"", ""ProgressTracking"", ""Notes""]
        //  }
        //}";

        // Function schema for the workout plan
        private static readonly ChatResponseFormat WorkoutPlanResponseFormat = ChatResponseFormat.CreateJsonSchemaFormat(
     jsonSchemaIsStrict: true,
     jsonSchemaFormatName: "workout_plan",
     jsonSchema: BinaryData.FromBytes("""
{
    "$schema": "https://json-schema.org/draft/2019-09/schema",
    "title": "workout plan",
    "description": "description of a workout plan for a week, including exercises, sets, reps, and rest times.",
    "type": "object",
    "additionalProperties": false,
    "required": [
        "duration",
        "goal",
        "daily_plans",
        "rest_days",
        "notes"
    ],
    "properties": {
        "duration": {
            "description": "The duration of the workout plan.",
            "type": "string"
        },
        "goal": {
            "description": "The goal of the workout plan (e.g., build muscle, improve strength).",
            "type": "string"
        },
        "daily_plans": {
            "description": "Daily workout plans for the week.",
            "type": "array",
            "items": {
                "$ref": "#/$defs/day"
            }
        },
        "rest_days": {
            "description": "Rest days in the workout plan.",
            "type": "array",
            "items": {
                "type": "string"
            }
        },
        "notes": {
            "description": "Additional notes or comments.",
            "type": "array",
            "items": {
                "type": "string"
            }
        }
    },
    "$defs": {
        "day": {
            "type": "object",
            "additionalProperties": false,
            "required": [
                "day",
                "focus",
                "exercises"
            ],
            "properties": {
                "day": {
                    "description": "The day of the week (e.g., Monday).",
                    "type": "string"
                },
                "focus": {
                    "description": "The focus of the workout (e.g., Upper Body Strength).",
                    "type": "string"
                },
                "exercises": {
                    "description": "List of exercises for the day.",
                    "type": "array",
                    "items": {
                        "$ref": "#/$defs/exercise"
                    }
                }
            }
        },
        "exercise": {
            "description": "Details of an exercise.",
            "type": "object",
            "additionalProperties": false,
            "required": [
                "name",
                "muscle_group",
                "sets",
                "reps",
                "rest_between_sets",
                "intensity",
                "notes"
            ],
            "properties": {
                "name": {
                    "description": "The name of the exercise.",
                    "type": "string"
                },
                "muscle_group": {
                    "description": "The muscle group targeted by the exercise.",
                    "type": "string"
                },
                "sets": {
                    "description": "The number of sets.",
                    "type": "integer"
                },
                "reps": {
                    "description": "The number of reps (e.g., 8-10).",
                    "type": "string"
                },
                "rest_between_sets": {
                    "description": "The rest time between sets (e.g., 60 seconds).",
                    "type": "string"
                },
                "intensity": {
                    "description": "The intensity level (e.g., Moderate, Heavy).",
                    "type": "string"
                },
                "notes": {
                    "description": "Additional notes or tips for the exercise.",
                    "type": "array",
                    "items": {
                        "type": "string"
                    }
                }
            }
        }
    }
}
"""u8.ToArray())
 );

        public PlanGenerationService(HttpClient httpClient, IConfiguration configuration, ILogger<PlanGenerationService> logger)
        {
            _httpClient = httpClient;
            _openAiApiKey = configuration["OpenAI:ApiKey"];
            _logger = logger;
            _chatClient = new ChatClient("gpt-4o-mini", _openAiApiKey);
        }

        public async Task<StructuredDietPlan> GenerateDietPlanAsync(UserProfile userProfile)
        {
            string prompt = GenerateDietPlanPrompt(userProfile);

            List<ChatMessage> messages = [
                new UserChatMessage(prompt)
            ];

            ChatCompletionOptions options = new()
            {
                ResponseFormat = DietPlanResponseFormat
            };

            ChatCompletion completion = await _chatClient.CompleteChatAsync(messages, options);

            using JsonDocument structuredJson = JsonDocument.Parse(completion.Content[0].Text);

            _logger.LogInformation(structuredJson.RootElement.ToString());

            return new StructuredDietPlan
            {
                UserProfileId = userProfile.Id,
                PlanJson = structuredJson.RootElement.ToString(),
            };
        }

        public async Task<StructuredWorkoutPlan> GenerateWorkoutPlanAsync(UserProfile userProfile)
        {
            try
            {
                string prompt = GenerateWorkoutPlanPrompt(userProfile);

                List<ChatMessage> messages = [new UserChatMessage(prompt)];
                ChatCompletionOptions options = new()
                {
                    ResponseFormat = WorkoutPlanResponseFormat
                };

                ChatCompletion completion = await _chatClient.CompleteChatAsync(messages, options);
                using JsonDocument structuredJson = JsonDocument.Parse(completion.Content[0].Text);

                _logger.LogInformation("Generated workout plan: {Plan}", structuredJson.RootElement.ToString());

                return new StructuredWorkoutPlan
                {
                    UserProfileId = userProfile.Id,
                    PlanJson = structuredJson.RootElement.ToString(),
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to generate workout plan for user profile {UserProfileId}", userProfile.Id);
                throw; // Re-throw the exception or return a default/error response
            }
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
Please ensure that the data you provide adheres to the specified schema and uses the new consistent format.
""";
        }
        private string GenerateWorkoutPlanPrompt(UserProfile userProfile)
        {
            return $"""
The user is an {userProfile.Age}-year-old {userProfile.Gender} with a height of {userProfile.Height} meters and a weight of {userProfile.Weight} kg.
Their fitness level is {userProfile.FitnessLevel}, and they aim to {userProfile.Goal}.
They work out {userProfile.WeeklyWorkoutDays} days a week, for {userProfile.WorkoutDuration} per session.
The plan should include exercises for strength, cardio, and flexibility, with rest days included.
**Include at least 4-6 exercises per workout day, targeting different muscle groups.**
**Use specific exercise names like Fly Machine, Lat Pulldown, Bench Press, Squats, etc., based on the user's goals and fitness level.**
**Ensure the plan is tailored to their fitness level and goals.**
**The plan must cover one full week (7 days) with detailed daily plans, including exercises, sets, reps, rest times, and intensity levels.**
**Include rest days and additional notes for each day.**
**Do not leave any fields null or incomplete.**
Please ensure that the data you provide adheres to the specified schema.
""";
        }
    }
}