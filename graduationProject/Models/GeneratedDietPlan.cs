using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace graduationProject.Models
{
    public class GeneratedDietPlan
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [ForeignKey(nameof(UserProfile))]
        public int UserProfileId { get; set; } // Link to the user profile who generated the plan
        
        public string MealPlan { get; set; } = string.Empty; // AI-generated meal plan description
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // When the plan was generated

        // Navigation property
        public virtual UserProfile UserProfile { get; set; } = null!;
    }
}