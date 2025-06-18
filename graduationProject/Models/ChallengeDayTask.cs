using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace graduationProject.Models
{
    public class ChallengeDayTask
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [ForeignKey(nameof(Challenge))]
        public int ChallengeId { get; set; }
        
        [Required]
        [Range(1, 28)]
        public int DayNumber { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;
        
        [Required]
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Tip { get; set; }
        
        // Which level this day belongs to (1-4)
        [Required]
        [Range(1, 4)]
        public int Level { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        // Navigation properties
        [JsonIgnore]
        public virtual Challenge Challenge { get; set; } = null!;
    }
} 