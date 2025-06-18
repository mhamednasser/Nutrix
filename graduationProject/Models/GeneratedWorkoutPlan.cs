using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace graduationProject.Models
{
    public class GeneratedWorkoutPlan
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [ForeignKey(nameof(UserProfile))]
        public int UserProfileId { get; set; } // Link to the user profile who generated the plan
        
        public string PlanDetails { get; set; } = string.Empty; // AI-generated workout details
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // When the plan was generated

        // Navigation property
        public virtual UserProfile UserProfile { get; set; } = null!;
    }
}