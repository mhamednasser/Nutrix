namespace graduationProject.DTOs
{
    public class ChallengeOverviewDto
    {
        public string ChallengeTitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsStarted { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public int CurrentDay { get; set; }
        public int CurrentLevel { get; set; }
        public int TotalDays { get; set; } = 28;
        public int CompletedDaysCount { get; set; }
        public double ProgressPercentage { get; set; }
        public bool IsChallengeCompleted { get; set; }
        public List<ChallengeLevelSummaryDto> Levels { get; set; } = new();
    }

    public class ChallengeLevelSummaryDto
    {
        public int LevelId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsUnlocked { get; set; }
        public bool IsCompleted { get; set; }
        public int CompletedDaysCount { get; set; }
        public int TotalDaysCount { get; set; } = 7;
        public double ProgressPercentage { get; set; }
        public int StartDay { get; set; } // Day 1, 8, 15, 22
        public int EndDay { get; set; }   // Day 7, 14, 21, 28
    }

    public class ChallengeLevelDetailDto
    {
        public int LevelId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsUnlocked { get; set; }
        public bool IsCompleted { get; set; }
        public int StartDay { get; set; }
        public int EndDay { get; set; }
        public List<ChallengeDayTaskDto> Days { get; set; } = new();
    }

    public class ChallengeDayTaskDto
    {
        public int DayNumber { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? Tip { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsUnlocked { get; set; }
        public DateTime? CompletedAt { get; set; }
    }

    public class ChallengeStatsDto
    {
        public int TotalDaysCompleted { get; set; }
        public int TotalDaysAvailable { get; set; } = 28;
        public int CompletedLevels { get; set; }
        public int CurrentLevel { get; set; }
        public int CurrentStreak { get; set; }
        public int LongestStreak { get; set; }
        public DateTime? StartDate { get; set; }
        public int DaysActive { get; set; }
        public double CompletionRate { get; set; }
        public DateTime? EstimatedCompletionDate { get; set; }
        public string Status { get; set; } = string.Empty; // "Not Started", "In Progress", "Completed"
    }

    public class CompleteDayResponseDto
    {
        public string Message { get; set; } = string.Empty;
        public int DayNumber { get; set; }
        public DateTime CompletedAt { get; set; }
        public bool LevelCompleted { get; set; }
        public int? NextLevelUnlocked { get; set; }
        public bool ChallengeCompleted { get; set; }
        public int TotalCompletedDays { get; set; }
        public double ProgressPercentage { get; set; }
    }
} 