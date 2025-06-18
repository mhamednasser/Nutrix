using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace graduationProject.Models
{
    public class StructuredWorkoutPlan
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
        public WorkoutPlanData? PlanData
        {
            get
            {
                if (string.IsNullOrEmpty(PlanJson))
                    return null;
                try
                {
                    return JsonSerializer.Deserialize<WorkoutPlanData>(PlanJson);
                }
                catch
                {
                    return null;
                }
            }
            set => PlanJson = value != null ? JsonSerializer.Serialize(value) : string.Empty;
        }
    }

    public class WorkoutPlanData
    {
        [JsonPropertyName("duration")]
        public string Duration { get; set; } = string.Empty;

        [JsonPropertyName("goal")]
        public string Goal { get; set; } = string.Empty;

        [JsonPropertyName("daily_plans")]
        public List<DailyWorkoutPlan> DailyPlans { get; set; } = new List<DailyWorkoutPlan>();

        [JsonPropertyName("rest_days")]
        public List<string> RestDays { get; set; } = new List<string>();

        [JsonPropertyName("notes")]
        public List<string> Notes { get; set; } = new List<string>();
    }

    public class DailyWorkoutPlan
    {
        [JsonPropertyName("day")]
        public string Day { get; set; } = string.Empty;

        [JsonPropertyName("focus")]
        public string Focus { get; set; } = string.Empty;

        [JsonPropertyName("exercises")]
        public List<WorkoutExercise> Exercises { get; set; } = new List<WorkoutExercise>();
    }

    public class WorkoutExercise
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("muscle_group")]
        public string MuscleGroup { get; set; } = string.Empty;

        [JsonPropertyName("sets")]
        public int Sets { get; set; }

        [JsonPropertyName("reps")]
        public string Reps { get; set; } = string.Empty;

        [JsonPropertyName("rest_between_sets")]
        public string RestBetweenSets { get; set; } = string.Empty;

        [JsonPropertyName("intensity")]
        public string Intensity { get; set; } = string.Empty;

        [JsonPropertyName("notes")]
        public List<string> Notes { get; set; } = new List<string>();
    }
}