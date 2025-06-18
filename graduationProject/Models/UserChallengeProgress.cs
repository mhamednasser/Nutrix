using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace graduationProject.Models
{
    public class UserChallengeProgress
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [ForeignKey(nameof(UserProfile))]
        public int UserProfileId { get; set; }
        
        [Required]
        [ForeignKey(nameof(Challenge))]
        public int ChallengeId { get; set; }
        
        public DateTime StartedAt { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedAt { get; set; }
        public bool IsActive { get; set; } = true;
        
        // Current progress tracking
        public int CurrentDay { get; set; } = 1; // Days 1-28
        public int CurrentLevel { get; set; } = 1; // Levels 1-4
        
        // JSON field to store completed days (flexible approach)
        [Column(TypeName = "nvarchar(max)")]
        public string CompletedDaysJson { get; set; } = "[]";
        
        // Helper property to work with completed days
        [NotMapped]
        public List<int> CompletedDays
        {
            get => string.IsNullOrEmpty(CompletedDaysJson) 
                ? new List<int>() 
                : JsonSerializer.Deserialize<List<int>>(CompletedDaysJson) ?? new List<int>();
            set => CompletedDaysJson = JsonSerializer.Serialize(value);
        }
        
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
        // Navigation properties
        [JsonIgnore]
        public virtual UserProfile UserProfile { get; set; } = null!;
        
        [JsonIgnore]
        public virtual Challenge Challenge { get; set; } = null!;
        
        // Helper methods
        public bool IsDayCompleted(int dayNumber) => CompletedDays.Contains(dayNumber);
        
        public void CompleteDay(int dayNumber)
        {
            if (!CompletedDays.Contains(dayNumber))
            {
                var days = CompletedDays;
                days.Add(dayNumber);
                CompletedDays = days;
                UpdatedAt = DateTime.UtcNow;
            }
        }
        
        public int GetCompletedDaysCount() => CompletedDays.Count;
        
        public bool IsLevelCompleted(int level)
        {
            var levelStartDay = (level - 1) * 7 + 1;
            var levelEndDay = level * 7;
            
            for (int day = levelStartDay; day <= levelEndDay; day++)
            {
                if (!CompletedDays.Contains(day))
                    return false;
            }
            return true;
        }
        
        public bool IsChallengeCompleted() => CompletedDays.Count >= 28;
    }
} 