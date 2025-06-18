namespace graduationProject.DTOs
{
    // Diet Plan DTOs
    public class GeneralDietPlanListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Difficulty { get; set; } = string.Empty;
        public int Duration { get; set; }
        public int DailyCalories { get; set; }
    }

    public class GeneralDietPlanDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int Duration { get; set; }
        public int DailyCalories { get; set; }
        public string Difficulty { get; set; } = string.Empty;
        public string Goals { get; set; } = string.Empty;
        public int ProteinPercentage { get; set; }
        public int CarbPercentage { get; set; }
        public int FatPercentage { get; set; }
        public string KeyFeatures { get; set; } = string.Empty;
        public string Benefits { get; set; } = string.Empty;
        public string VideoUrl { get; set; } = string.Empty;
        public List<MealItemDto> Breakfast { get; set; } = new();
        public List<MealItemDto> Lunch { get; set; } = new();
        public List<MealItemDto> Dinner { get; set; } = new();
    }

    public class MealItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int Calories { get; set; }
        public int Time { get; set; } // in minutes
    }

    public class MealDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string VideoUrl { get; set; } = string.Empty;
        public int Calories { get; set; }
        public int Time { get; set; }
        public MacrosDto Macros { get; set; } = new();
        public List<string> Ingredients { get; set; } = new();
        public List<string> Steps { get; set; } = new();
        public List<string> Benefits { get; set; } = new();
    }

    public class MacrosDto
    {
        public int Fat { get; set; }
        public int Protein { get; set; }
        public int Carbs { get; set; }
    }

    // Workout Plan DTOs
    public class GeneralWorkoutPlanListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Difficulty { get; set; } = string.Empty;
        public int Duration { get; set; }
        public int ExerciseCount { get; set; }
        public int CaloriesBurned { get; set; }
    }

    public class GeneralWorkoutPlanDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int Duration { get; set; }
        public int ExerciseCount { get; set; }
        public string Difficulty { get; set; } = string.Empty;
        public string Goals { get; set; } = string.Empty;
        public int CaloriesBurned { get; set; }
        public string KeyFeatures { get; set; } = string.Empty;
        public string Benefits { get; set; } = string.Empty;
        public string TargetMuscles { get; set; } = string.Empty;
        public string Equipment { get; set; } = string.Empty;
        public string VideoUrl { get; set; } = string.Empty;
        public List<WorkoutDayDto> Days { get; set; } = new();
    }

    public class WorkoutDayDto
    {
        public int Day { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<ExerciseItemDto> Exercises { get; set; } = new();
    }

    public class ExerciseItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int Duration { get; set; } // in seconds
        public int RestTime { get; set; } // in seconds
    }

    public class ExerciseDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string VideoUrl { get; set; } = string.Empty;
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int Duration { get; set; }
        public int RestTime { get; set; }
        public string TargetMuscle { get; set; } = string.Empty;
        public string Equipment { get; set; } = string.Empty;
        public string Difficulty { get; set; } = string.Empty;
        public List<string> Instructions { get; set; } = new();
        public List<string> Tips { get; set; } = new();
        public List<string> Benefits { get; set; } = new();
    }

    // Complete data DTOs for overview endpoints
    public class AllDietPlansDto
    {
        public List<GeneralDietPlanDetailDto> Plans { get; set; } = new();
        public int TotalPlans { get; set; }
        public List<string> Categories { get; set; } = new();
    }

    public class AllWorkoutPlansDto
    {
        public List<GeneralWorkoutPlanDetailDto> Plans { get; set; } = new();
        public int TotalPlans { get; set; }
        public List<string> Categories { get; set; } = new();
    }
} 