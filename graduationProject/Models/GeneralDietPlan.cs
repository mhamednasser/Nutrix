using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace graduationProject.Models
{
    public class GeneralDietPlan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Category { get; set; } = string.Empty;

        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        [StringLength(500)]
        public string ImageUrl { get; set; } = string.Empty;

        public int Duration { get; set; } // in days

        public int DailyCalories { get; set; }

        [StringLength(50)]
        public string Difficulty { get; set; } = string.Empty;

        [StringLength(500)]
        public string Goals { get; set; } = string.Empty;

        public int ProteinPercentage { get; set; }
        public int CarbPercentage { get; set; }
        public int FatPercentage { get; set; }

        [StringLength(500)]
        public string KeyFeatures { get; set; } = string.Empty;

        [StringLength(500)]
        public string Benefits { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(max)")]
        public string PlanDetailsJson { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = true;

        [StringLength(500)]
        public string VideoUrl { get; set; } = string.Empty;
    }
} 