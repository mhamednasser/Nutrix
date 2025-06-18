using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace graduationProject.Models
{
    public class AppUser : IdentityUser
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastLoginAt { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation property to UserProfile (One-to-One relationship)
        [JsonIgnore]
        public virtual UserProfile? UserProfile { get; set; }
    }
}



