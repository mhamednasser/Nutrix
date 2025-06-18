using graduationProject.DTOs;
using graduationProject.Repositories;
using System.Text.Json;

namespace graduationProject.Services
{
    public class GeneralPlanService : IGeneralPlanService
    {
        private readonly IGeneralPlanRepository _repository;

        public GeneralPlanService(IGeneralPlanRepository repository)
        {
            _repository = repository;
        }

        // Diet Plan Services
        public async Task<IEnumerable<GeneralDietPlanListDto>> GetAllDietPlansAsync()
        {
            var plans = await _repository.GetAllDietPlansAsync();
            return plans.Select(p => new GeneralDietPlanListDto
            {
                Id = p.Id,
                Name = p.Name,
                Category = p.Category,
                ImageUrl = p.ImageUrl,
                Difficulty = p.Difficulty,
                Duration = p.Duration,
                DailyCalories = p.DailyCalories
            });
        }

        public async Task<GeneralDietPlanDetailDto?> GetDietPlanByIdAsync(int id)
        {
            var plan = await _repository.GetDietPlanByIdAsync(id);
            if (plan == null) return null;

            var planDetails = JsonSerializer.Deserialize<dynamic>(plan.PlanDetailsJson);
            var planDetailsDict = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(plan.PlanDetailsJson);

            if (planDetailsDict == null) return null;

            return new GeneralDietPlanDetailDto
            {
                Id = plan.Id,
                Name = plan.Name,
                Category = plan.Category,
                Description = plan.Description,
                ImageUrl = plan.ImageUrl,
                Duration = plan.Duration,
                DailyCalories = plan.DailyCalories,
                Difficulty = plan.Difficulty,
                Goals = plan.Goals,
                ProteinPercentage = plan.ProteinPercentage,
                CarbPercentage = plan.CarbPercentage,
                FatPercentage = plan.FatPercentage,
                KeyFeatures = plan.KeyFeatures,
                Benefits = plan.Benefits,
                VideoUrl = plan.VideoUrl,
                Breakfast = ExtractMealItems(planDetailsDict, "breakfast"),
                Lunch = ExtractMealItems(planDetailsDict, "lunch"),
                Dinner = ExtractMealItems(planDetailsDict, "dinner")
            };
        }

        public async Task<MealDetailDto?> GetMealDetailAsync(int mealId)
        {
            var plans = await _repository.GetAllDietPlansAsync();
            
            foreach (var plan in plans)
            {
                var planDetailsDict = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(plan.PlanDetailsJson);
                
                if (planDetailsDict == null) continue;
                
                // Search in breakfast, lunch, dinner
                foreach (var mealType in new[] { "breakfast", "lunch", "dinner" })
                {
                    if (planDetailsDict.ContainsKey(mealType))
                    {
                        var meals = JsonSerializer.Deserialize<List<Dictionary<string, JsonElement>>>(planDetailsDict[mealType].GetRawText());
                        var meal = meals?.FirstOrDefault(m => m.ContainsKey("id") && m["id"].GetInt32() == mealId);
                        
                        if (meal != null)
                        {
                            return new MealDetailDto
                            {
                                Id = meal["id"].GetInt32(),
                                Name = meal["name"].GetString() ?? "",
                                ImageUrl = meal["imageUrl"].GetString() ?? "",
                                VideoUrl = meal["videoUrl"].GetString() ?? "",
                                Calories = meal["calories"].GetInt32(),
                                Time = meal["time"].GetInt32(),
                                Macros = ExtractMacros(meal["macros"]),
                                Ingredients = ExtractStringArray(meal["ingredients"]),
                                Steps = ExtractStringArray(meal["steps"]),
                                Benefits = ExtractStringArray(meal["benefits"])
                            };
                        }
                    }
                }
            }
            
            return null;
        }

        public async Task<IEnumerable<string>> GetDietCategoriesAsync()
        {
            return await _repository.GetDietCategoriesAsync();
        }

        public async Task<AllDietPlansDto> GetAllDietDataAsync()
        {
            var plans = await _repository.GetAllDietPlansAsync();
            var detailedPlans = new List<GeneralDietPlanDetailDto>();

            foreach (var plan in plans)
            {
                var detailedPlan = await GetDietPlanByIdAsync(plan.Id);
                if (detailedPlan != null)
                {
                    detailedPlans.Add(detailedPlan);
                }
            }

            return new AllDietPlansDto
            {
                Plans = detailedPlans,
                TotalPlans = detailedPlans.Count,
                Categories = (await GetDietCategoriesAsync()).ToList()
            };
        }

        // Workout Plan Services
        public async Task<IEnumerable<GeneralWorkoutPlanListDto>> GetAllWorkoutPlansAsync()
        {
            var plans = await _repository.GetAllWorkoutPlansAsync();
            return plans.Select(p => new GeneralWorkoutPlanListDto
            {
                Id = p.Id,
                Name = p.Name,
                Category = p.Category,
                ImageUrl = p.ImageUrl,
                Difficulty = p.Difficulty,
                Duration = p.Duration,
                ExerciseCount = p.ExerciseCount,
                CaloriesBurned = p.CaloriesBurned
            });
        }

        public async Task<GeneralWorkoutPlanDetailDto?> GetWorkoutPlanByIdAsync(int id)
        {
            var plan = await _repository.GetWorkoutPlanByIdAsync(id);
            if (plan == null) return null;

            var planDetailsDict = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(plan.PlanDetailsJson);

            if (planDetailsDict == null) return null;

            return new GeneralWorkoutPlanDetailDto
            {
                Id = plan.Id,
                Name = plan.Name,
                Category = plan.Category,
                Description = plan.Description,
                ImageUrl = plan.ImageUrl,
                Duration = plan.Duration,
                ExerciseCount = plan.ExerciseCount,
                Difficulty = plan.Difficulty,
                Goals = plan.Goals,
                CaloriesBurned = plan.CaloriesBurned,
                KeyFeatures = plan.KeyFeatures,
                Benefits = plan.Benefits,
                TargetMuscles = plan.TargetMuscles,
                Equipment = plan.Equipment,
                VideoUrl = plan.VideoUrl,
                Days = ExtractWorkoutDays(planDetailsDict)
            };
        }

        public async Task<ExerciseDetailDto?> GetExerciseDetailAsync(int exerciseId)
        {
            var plans = await _repository.GetAllWorkoutPlansAsync();
            
            foreach (var plan in plans)
            {
                var planDetailsDict = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(plan.PlanDetailsJson);
                
                if (planDetailsDict == null) continue;
                
                if (planDetailsDict.ContainsKey("days"))
                {
                    var days = JsonSerializer.Deserialize<List<Dictionary<string, JsonElement>>>(planDetailsDict["days"].GetRawText());
                    
                    foreach (var day in days ?? new List<Dictionary<string, JsonElement>>())
                    {
                        if (day.ContainsKey("exercises"))
                        {
                            var exercises = JsonSerializer.Deserialize<List<Dictionary<string, JsonElement>>>(day["exercises"].GetRawText());
                            var exercise = exercises?.FirstOrDefault(e => e.ContainsKey("id") && e["id"].GetInt32() == exerciseId);
                            
                            if (exercise != null)
                            {
                                return new ExerciseDetailDto
                                {
                                    Id = exercise["id"].GetInt32(),
                                    Name = exercise["name"].GetString() ?? "",
                                    ImageUrl = exercise["imageUrl"].GetString() ?? "",
                                    VideoUrl = exercise["videoUrl"].GetString() ?? "",
                                    Sets = exercise["sets"].GetInt32(),
                                    Reps = exercise["reps"].GetInt32(),
                                    Duration = exercise["duration"].GetInt32(),
                                    RestTime = exercise["restTime"].GetInt32(),
                                    TargetMuscle = exercise["targetMuscle"].GetString() ?? "",
                                    Equipment = exercise["equipment"].GetString() ?? "",
                                    Difficulty = exercise["difficulty"].GetString() ?? "",
                                    Instructions = ExtractStringArray(exercise["instructions"]),
                                    Tips = ExtractStringArray(exercise["tips"]),
                                    Benefits = ExtractStringArray(exercise["benefits"])
                                };
                            }
                        }
                    }
                }
            }
            
            return null;
        }

        public async Task<IEnumerable<string>> GetWorkoutCategoriesAsync()
        {
            return await _repository.GetWorkoutCategoriesAsync();
        }

        public async Task<AllWorkoutPlansDto> GetAllWorkoutDataAsync()
        {
            var plans = await _repository.GetAllWorkoutPlansAsync();
            var detailedPlans = new List<GeneralWorkoutPlanDetailDto>();

            foreach (var plan in plans)
            {
                var detailedPlan = await GetWorkoutPlanByIdAsync(plan.Id);
                if (detailedPlan != null)
                {
                    detailedPlans.Add(detailedPlan);
                }
            }

            return new AllWorkoutPlansDto
            {
                Plans = detailedPlans,
                TotalPlans = detailedPlans.Count,
                Categories = (await GetWorkoutCategoriesAsync()).ToList()
            };
        }

        public async Task InitializeDataAsync()
        {
            await _repository.SeedDietPlansAsync();
            await _repository.SeedWorkoutPlansAsync();
        }

        // Helper Methods
        private List<MealItemDto> ExtractMealItems(Dictionary<string, JsonElement> planDetails, string mealType)
        {
            if (!planDetails.ContainsKey(mealType)) return new List<MealItemDto>();

            var meals = JsonSerializer.Deserialize<List<Dictionary<string, JsonElement>>>(planDetails[mealType].GetRawText());
            return meals?.Select(m => new MealItemDto
            {
                Id = m["id"].GetInt32(),
                Name = m["name"].GetString() ?? "",
                ImageUrl = m["imageUrl"].GetString() ?? "",
                Calories = m["calories"].GetInt32(),
                Time = m["time"].GetInt32()
            }).ToList() ?? new List<MealItemDto>();
        }

        private MacrosDto ExtractMacros(JsonElement macrosElement)
        {
            var macros = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(macrosElement.GetRawText());
            return new MacrosDto
            {
                Fat = macros!["fat"].GetInt32(),
                Protein = macros["protein"].GetInt32(),
                Carbs = macros["carbs"].GetInt32()
            };
        }

        private List<string> ExtractStringArray(JsonElement arrayElement)
        {
            var items = JsonSerializer.Deserialize<List<string>>(arrayElement.GetRawText());
            return items ?? new List<string>();
        }

        private List<WorkoutDayDto> ExtractWorkoutDays(Dictionary<string, JsonElement> planDetails)
        {
            if (!planDetails.ContainsKey("days")) return new List<WorkoutDayDto>();

            var days = JsonSerializer.Deserialize<List<Dictionary<string, JsonElement>>>(planDetails["days"].GetRawText());
            return days?.Select(d => new WorkoutDayDto
            {
                Day = d["day"].GetInt32(),
                Name = d["name"].GetString() ?? "",
                Exercises = ExtractExerciseItems(d["exercises"])
            }).ToList() ?? new List<WorkoutDayDto>();
        }

        private List<ExerciseItemDto> ExtractExerciseItems(JsonElement exercisesElement)
        {
            var exercises = JsonSerializer.Deserialize<List<Dictionary<string, JsonElement>>>(exercisesElement.GetRawText());
            return exercises?.Select(e => new ExerciseItemDto
            {
                Id = e["id"].GetInt32(),
                Name = e["name"].GetString() ?? "",
                ImageUrl = e["imageUrl"].GetString() ?? "",
                Sets = e["sets"].GetInt32(),
                Reps = e["reps"].GetInt32(),
                Duration = e["duration"].GetInt32(),
                RestTime = e["restTime"].GetInt32()
            }).ToList() ?? new List<ExerciseItemDto>();
        }
    }
} 