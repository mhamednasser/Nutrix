using System.Text.Json.Serialization;

namespace graduationProject.DTOs
{
    public class DietPlanDto
    {
        [JsonPropertyName("duration")]
        public string Duration { get; set; } = string.Empty;

        [JsonPropertyName("goal")]
        public string Goal { get; set; } = string.Empty;

        [JsonPropertyName("daily_plans")]
        public List<DietPlanDayDto> DailyPlans { get; set; } = new List<DietPlanDayDto>();

        [JsonPropertyName("notes")]
        public List<string> Notes { get; set; } = new List<string>();
    }

    public class DietPlanDayDto
    {
        [JsonPropertyName("day")]
        public string Day { get; set; } = string.Empty;

        [JsonPropertyName("meals")]
        public DietPlanMealsDto Meals { get; set; } = new DietPlanMealsDto();
    }

    public class DietPlanMealsDto
    {
        [JsonPropertyName("breakfast")]
        public DietPlanMealDto Breakfast { get; set; } = new DietPlanMealDto();

        [JsonPropertyName("lunch")]
        public DietPlanMealDto Lunch { get; set; } = new DietPlanMealDto();

        [JsonPropertyName("dinner")]
        public DietPlanMealDto Dinner { get; set; } = new DietPlanMealDto();
    }

    public class DietPlanMealDto
    {
        [JsonPropertyName("main")]
        public DietPlanDishDto Main { get; set; } = new DietPlanDishDto();

        [JsonPropertyName("alternatives")]
        public List<DietPlanDishDto> Alternatives { get; set; } = new List<DietPlanDishDto>();
    }

    public class DietPlanDishDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("portion")]
        public string Portion { get; set; } = string.Empty;

        [JsonPropertyName("calories")]
        public double Calories { get; set; }

        [JsonPropertyName("macronutrients")]
        public DietPlanMacronutrientsDto Macronutrients { get; set; } = new DietPlanMacronutrientsDto();
    }

    public class DietPlanMacronutrientsDto
    {
        [JsonPropertyName("carbs")]
        public double Carbs { get; set; }

        [JsonPropertyName("protein")]
        public double Protein { get; set; }

        [JsonPropertyName("fat")]
        public double Fat { get; set; }
    }
}
