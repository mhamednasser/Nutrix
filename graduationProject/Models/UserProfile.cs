using graduationProject.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace graduationProject.Models
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(AppUser))]
        public string AppUserId { get; set; } = string.Empty;

        [Range(15, 100)]
        public int Age { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Range(0.5, 3.0)]
        public double Height { get; set; }

        [Range(30, 300)]
        public double Weight { get; set; }

        [Required]
        public FitnessLevel FitnessLevel { get; set; }

        [Range(1, 7)]
        public int WeeklyWorkoutDays { get; set; }

        [Required]
        [StringLength(50)]
        public string WorkoutDuration { get; set; } = string.Empty;

        [Required]
        public Goal Goal { get; set; }

        [StringLength(500)]
        public string? DietaryRestrictions { get; set; }

        [Required]
        public PreferredDiet PreferredDiet { get; set; }

        [StringLength(500)]
        public string? MedicalConditions { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        [JsonIgnore]
        public virtual AppUser AppUser { get; set; } = null!;

        // Navigation properties for plans
        [JsonIgnore]
        public virtual ICollection<StructuredDietPlan> StructuredDietPlans { get; set; } = new List<StructuredDietPlan>();
        
        [JsonIgnore]
        public virtual ICollection<StructuredWorkoutPlan> StructuredWorkoutPlans { get; set; } = new List<StructuredWorkoutPlan>();
    }
} 