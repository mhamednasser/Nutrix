using System.ComponentModel.DataAnnotations;

namespace graduationProject.DTOs
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }

    public enum FitnessLevel
    {
        Beginner,
        Intermediate,
        Advanced
    }

    public enum Goal
    {
        GainingMuscle,
        BurningFat,
        ImprovingHealth,
        ReducingStress
    }

    public enum PreferredDiet
    {
        Balanced,
        Mediterranean,
        LowCarb,
        Dash,
        Keto
    }

    public class UserProfileDto
    {
        [Required(ErrorMessage = "Age is required")]
        [Range(15, 100, ErrorMessage = "Age must be between 15 and 100")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Height is required")]
        [Range(0.5, 3.0, ErrorMessage = "Height must be between 0.5 and 3.0 meters")]
        public double Height { get; set; }

        [Required(ErrorMessage = "Weight is required")]
        [Range(30, 300, ErrorMessage = "Weight must be between 30 and 300 kg")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Fitness level is required")]
        public FitnessLevel FitnessLevel { get; set; }

        [Required(ErrorMessage = "Weekly workout days is required")]
        [Range(1, 7, ErrorMessage = "Weekly workout days must be between 1 and 7")]
        public int WeeklyWorkoutDays { get; set; }

        [Required(ErrorMessage = "Workout duration is required")]
        [StringLength(50, ErrorMessage = "Workout duration cannot exceed 50 characters")]
        public string WorkoutDuration { get; set; } = string.Empty;

        [Required(ErrorMessage = "Goal is required")]
        public Goal Goal { get; set; }

        [StringLength(500, ErrorMessage = "Dietary restrictions cannot exceed 500 characters")]
        public string? DietaryRestrictions { get; set; }

        [Required(ErrorMessage = "Preferred diet is required")]
        public PreferredDiet PreferredDiet { get; set; }

        [StringLength(500, ErrorMessage = "Medical conditions cannot exceed 500 characters")]
        public string? MedicalConditions { get; set; }
    }

    public class CreateUserProfileDto : UserProfileDto
    {
        // User ID will be extracted from JWT token - no need for client to provide it
        // Removed UserId field for security - user cannot specify which user to create profile for
    }

    public class UpdateUserProfileDto : UserProfileDto
    {
        // Inherits all validation from UserProfileDto
    }
} 