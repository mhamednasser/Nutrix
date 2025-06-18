using graduationProject.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace graduationProject.Models
{
    public class StructuredDietPlan
    {
        [Key]
        public int Id { get; set; } // Primary key
        
        [Required]
        [ForeignKey(nameof(UserProfile))]
        public int UserProfileId { get; set; } // Foreign key to UserProfile

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;

        [JsonIgnore] // Ignore during serialization to avoid circular reference
        public virtual UserProfile UserProfile { get; set; } = null!;

        // Store the entire plan as JSON
        [Column(TypeName = "nvarchar(max)")] // Use nvarchar(max) for SQL Server
        public string PlanJson { get; set; } = string.Empty;

        // Helper property to serialize/deserialize JSON
        [NotMapped] // This property will not be mapped to the database
        public DietPlanData? PlanData
        {
            get
            {
                if (string.IsNullOrEmpty(PlanJson))
                    return null;
                try
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                        AllowTrailingCommas = true
                    };
                    return JsonSerializer.Deserialize<DietPlanData>(PlanJson, options);
                }
                catch (JsonException ex)
                {
                    // Log the error for debugging but don't crash
                    System.Diagnostics.Debug.WriteLine($"Failed to deserialize diet plan JSON: {ex.Message}");
                    return null;
                }
            }
            set => PlanJson = value != null ? JsonSerializer.Serialize(value) : string.Empty;
        }

        // Helper property to get raw JSON as object for flexible frontend consumption
        [NotMapped]
        public object? PlanDataRaw
        {
            get
            {
                if (string.IsNullOrEmpty(PlanJson))
                    return null;
                try
                {
                    return JsonSerializer.Deserialize<object>(PlanJson);
                }
                catch
                {
                    return null;
                }
            }
        }
    }

    public class DietPlanData
    {
        [JsonPropertyName("duration")]
        public string Duration { get; set; } = string.Empty;

        [JsonPropertyName("goal")]
        public string Goal { get; set; } = string.Empty;

        [JsonPropertyName("daily_plans")]
        public List<DietDayPlan> DailyPlans { get; set; } = new List<DietDayPlan>();

        [JsonPropertyName("notes")]
        public List<string> Notes { get; set; } = new List<string>();
    }

    public class DietDayPlan
    {
        [JsonPropertyName("day")]
        public string Day { get; set; } = string.Empty;

        [JsonPropertyName("meals")]
        public DietMealsCollection Meals { get; set; } = new DietMealsCollection();
    }

    public class DietMealsCollection
    {
        [JsonPropertyName("breakfast")]
        public DietMeal Breakfast { get; set; } = new DietMeal();

        [JsonPropertyName("lunch")]
        public DietMeal Lunch { get; set; } = new DietMeal();

        [JsonPropertyName("dinner")]
        public DietMeal Dinner { get; set; } = new DietMeal();
    }

    public class DietMeal
    {
        [JsonPropertyName("main")]
        public DietDish Main { get; set; } = new DietDish();

        [JsonPropertyName("alternatives")]
        public List<DietDish> Alternatives { get; set; } = new List<DietDish>();
    }

    public class DietDish
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("portion")]
        public string Portion { get; set; } = string.Empty;

        [JsonPropertyName("calories")]
        public double Calories { get; set; }

        [JsonPropertyName("macronutrients")]
        public DietMacronutrients Macronutrients { get; set; } = new DietMacronutrients();
    }

    public class DietMacronutrients
    {
        [JsonPropertyName("carbs")]
        public double Carbs { get; set; }

        [JsonPropertyName("protein")]
        public double Protein { get; set; }

        [JsonPropertyName("fat")]
        public double Fat { get; set; }
    }
}





































//namespace graduationProject.Models
//{
//    public class StructuredDietPlan
//    {
//        public string Duration { get; set; }
//        public int DailyCalories { get; set; }
//        public string MacronutrientDistribution { get; set; }
//        public List<WeeklyPlan> WeeklyPlans { get; set; } = new List<WeeklyPlan>();
//        public List<ShoppingListItem> ShoppingList { get; set; } = new List<ShoppingListItem>();
//        public List<HydrationInstruction> HydrationPlan { get; set; } = new List<HydrationInstruction>();
//        public List<ProgressTrackingInstruction> ProgressTracking { get; set; } = new List<ProgressTrackingInstruction>();
//        public List<string> Notes { get; set; } = new List<string>();
//    }

//    public class WeeklyPlan
//    {
//        public int WeekNumber { get; set; }
//        public List<DailyPlan> DailyPlans { get; set; } = new List<DailyPlan>();
//    }

//    public class DailyPlan
//    {
//        public string Day { get; set; }
//        public List<Meal> Meals { get; set; } = new List<Meal>();
//    }

//    public class Meal
//    {
//        public string Name { get; set; }
//        public List<FoodItem> Items { get; set; } = new List<FoodItem>();
//    }

//    public class FoodItem
//    {
//        public string Name { get; set; }
//        public string PortionSize { get; set; }
//        public int Calories { get; set; }
//        public Macronutrients Macronutrients { get; set; } = new Macronutrients();
//        public List<FoodItem> Alternatives { get; set; } = new List<FoodItem>();
//    }

//    public class Macronutrients
//    {
//        public string Carbs { get; set; }
//        public string Protein { get; set; }
//        public string Fat { get; set; }
//    }

//    public class ShoppingListItem
//    {
//        public string Item { get; set; }
//        public string Quantity { get; set; }
//    }

//    public class HydrationInstruction
//    {
//        public string Time { get; set; }
//        public string Instruction { get; set; }
//    }

//    public class ProgressTrackingInstruction
//    {
//        public string Instruction { get; set; }
//    }
//}































//public class StructuredDietPlan
//{
//    public List<Meal> Meals { get; set; }
//    public List<string> Notes { get; set; } // Changed to a list
//}

//public class Meal
//{
//    public string Name { get; set; } // E.g., Breakfast, Snack, Lunch, etc.
//    public List<string> Items { get; set; } // List of food items
//}