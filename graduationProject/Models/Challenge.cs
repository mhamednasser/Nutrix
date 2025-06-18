using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace graduationProject.Models
{
    public class Challenge
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string ChallengeTitle { get; set; } = string.Empty;
        
        [Required]
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
        // Navigation properties
        [JsonIgnore]
        public virtual ICollection<ChallengeDayTask> DayTasks { get; set; } = new List<ChallengeDayTask>();
        
        [JsonIgnore]
        public virtual ICollection<UserChallengeProgress> UserProgress { get; set; } = new List<UserChallengeProgress>();
    }
} 