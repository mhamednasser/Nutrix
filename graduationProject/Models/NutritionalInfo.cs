using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace graduationProject.Models
{
    public class NutritionalInfo
    {
        public int Id { get; set; }
        public string JsonData { get; set; } = string.Empty; // Store raw JSON data as a string

        // Link to UserProfile instead of old User model
        public int UserProfileId { get; set; }
        
        // Navigation property
        [JsonIgnore]
        public virtual UserProfile UserProfile { get; set; } = null!;
    }
}