using graduationProject.DTOs;
using graduationProject.Interfaces;
using graduationProject.Models;
using Microsoft.EntityFrameworkCore;

namespace graduationProject.Services
{
    public class ChallengeService : IChallengeService
    {
        private readonly AppDbContext _context;
        private const int DEFAULT_CHALLENGE_ID = 1;

        public ChallengeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ChallengeOverviewDto> GetChallengeOverviewAsync(int userProfileId)
        {
            // Get the challenge with day tasks
            var challenge = await _context.Challenges
                .Include(c => c.DayTasks)
                .FirstOrDefaultAsync(c => c.Id == DEFAULT_CHALLENGE_ID);

            if (challenge == null)
                throw new InvalidOperationException("Challenge not found");

            // Get or create user progress
            var userProgress = await GetOrCreateUserProgressAsync(userProfileId, challenge.Id);

            // Build level summaries
            var levels = new List<ChallengeLevelSummaryDto>();
            for (int level = 1; level <= 4; level++)
            {
                var levelStartDay = (level - 1) * 7 + 1;
                var levelEndDay = level * 7;
                var levelCompletedDays = userProgress.CompletedDays
                    .Where(d => d >= levelStartDay && d <= levelEndDay)
                    .Count();

                levels.Add(new ChallengeLevelSummaryDto
                {
                    LevelId = level,
                    Title = $"Level {level}",
                    Description = GetLevelDescription(level),
                    IsUnlocked = IsLevelUnlocked(level, userProgress),
                    IsCompleted = userProgress.IsLevelCompleted(level),
                    CompletedDaysCount = levelCompletedDays,
                    TotalDaysCount = 7,
                    ProgressPercentage = Math.Round((double)levelCompletedDays / 7 * 100, 1),
                    StartDay = levelStartDay,
                    EndDay = levelEndDay
                });
            }

            return new ChallengeOverviewDto
            {
                ChallengeTitle = challenge.ChallengeTitle,
                Description = challenge.Description,
                IsStarted = userProgress.CompletedDays.Any(),
                StartedAt = userProgress.StartedAt,
                CompletedAt = userProgress.CompletedAt,
                CurrentDay = GetCurrentDay(userProgress),
                CurrentLevel = userProgress.CurrentLevel,
                TotalDays = 28,
                CompletedDaysCount = userProgress.GetCompletedDaysCount(),
                ProgressPercentage = Math.Round((double)userProgress.GetCompletedDaysCount() / 28 * 100, 1),
                IsChallengeCompleted = userProgress.IsChallengeCompleted(),
                Levels = levels
            };
        }

        public async Task<ChallengeLevelDetailDto> GetLevelDetailsAsync(int userProfileId, int levelId)
        {
            if (levelId < 1 || levelId > 4)
                throw new ArgumentException("Level ID must be between 1 and 4");

            var challenge = await _context.Challenges
                .Include(c => c.DayTasks)
                .FirstOrDefaultAsync(c => c.Id == DEFAULT_CHALLENGE_ID);

            if (challenge == null)
                throw new InvalidOperationException("Challenge not found");

            var userProgress = await GetOrCreateUserProgressAsync(userProfileId, challenge.Id);

            // Check if level is unlocked
            if (!IsLevelUnlocked(levelId, userProgress))
                throw new UnauthorizedAccessException("Level is not unlocked yet");

            var levelStartDay = (levelId - 1) * 7 + 1;
            var levelEndDay = levelId * 7;

            var levelDayTasks = challenge.DayTasks
                .Where(dt => dt.Level == levelId)
                .OrderBy(dt => dt.DayNumber)
                .Select(dt => new ChallengeDayTaskDto
                {
                    DayNumber = dt.DayNumber,
                    Title = dt.Title,
                    Description = dt.Description,
                    Tip = dt.Tip,
                    IsCompleted = userProgress.IsDayCompleted(dt.DayNumber),
                    IsUnlocked = IsDayUnlocked(dt.DayNumber, userProgress),
                    CompletedAt = userProgress.IsDayCompleted(dt.DayNumber) ? userProgress.UpdatedAt : null
                })
                .ToList();

            return new ChallengeLevelDetailDto
            {
                LevelId = levelId,
                Title = $"Level {levelId}",
                Description = GetLevelDescription(levelId),
                IsUnlocked = IsLevelUnlocked(levelId, userProgress),
                IsCompleted = userProgress.IsLevelCompleted(levelId),
                StartDay = levelStartDay,
                EndDay = levelEndDay,
                Days = levelDayTasks
            };
        }

        public async Task<CompleteDayResponseDto> CompleteDayAsync(int userProfileId, int dayNumber)
        {
            if (dayNumber < 1 || dayNumber > 28)
                throw new ArgumentException("Day number must be between 1 and 28");

            var challenge = await _context.Challenges
                .Include(c => c.DayTasks)
                .FirstOrDefaultAsync(c => c.Id == DEFAULT_CHALLENGE_ID);

            if (challenge == null)
                throw new InvalidOperationException("Challenge not found");

            var userProgress = await GetOrCreateUserProgressAsync(userProfileId, challenge.Id);

            // Check if day is unlocked
            if (!IsDayUnlocked(dayNumber, userProgress))
                throw new UnauthorizedAccessException("This day is not unlocked yet");

            // Check if already completed
            if (userProgress.IsDayCompleted(dayNumber))
                throw new InvalidOperationException("Day is already completed");

            // Complete the day
            userProgress.CompleteDay(dayNumber);
            
            // Update current day and level
            userProgress.CurrentDay = Math.Max(userProgress.CurrentDay, dayNumber + 1);
            userProgress.CurrentLevel = Math.Min((userProgress.CurrentDay - 1) / 7 + 1, 4);

            // Check if challenge is completed
            if (userProgress.IsChallengeCompleted() && userProgress.CompletedAt == null)
            {
                userProgress.CompletedAt = DateTime.UtcNow;
                userProgress.IsActive = false;
            }

            await _context.SaveChangesAsync();

            // Check level completion
            var currentLevel = (dayNumber - 1) / 7 + 1;
            var levelCompleted = userProgress.IsLevelCompleted(currentLevel);
            var nextLevelUnlocked = levelCompleted && currentLevel < 4 ? currentLevel + 1 : (int?)null;

            return new CompleteDayResponseDto
            {
                Message = $"Day {dayNumber} completed successfully!",
                DayNumber = dayNumber,
                CompletedAt = DateTime.UtcNow,
                LevelCompleted = levelCompleted,
                NextLevelUnlocked = nextLevelUnlocked,
                ChallengeCompleted = userProgress.IsChallengeCompleted(),
                TotalCompletedDays = userProgress.GetCompletedDaysCount(),
                ProgressPercentage = Math.Round((double)userProgress.GetCompletedDaysCount() / 28 * 100, 1)
            };
        }

        public async Task<ChallengeStatsDto> GetChallengeStatsAsync(int userProfileId)
        {
            var userProgress = await _context.UserChallengeProgress
                .FirstOrDefaultAsync(ucp => ucp.UserProfileId == userProfileId && ucp.ChallengeId == DEFAULT_CHALLENGE_ID);

            if (userProgress == null)
            {
                return new ChallengeStatsDto
                {
                    Status = "Not Started",
                    TotalDaysCompleted = 0,
                    TotalDaysAvailable = 28,
                    CompletedLevels = 0,
                    CurrentLevel = 1,
                    CurrentStreak = 0,
                    LongestStreak = 0,
                    DaysActive = 0,
                    CompletionRate = 0,
                    StartDate = null,
                    EstimatedCompletionDate = null
                };
            }

            var completedLevels = 0;
            for (int level = 1; level <= 4; level++)
            {
                if (userProgress.IsLevelCompleted(level))
                    completedLevels++;
            }

            var daysActive = userProgress.CompletedDays.Any() 
                ? (DateTime.UtcNow - userProgress.StartedAt).Days + 1 
                : 0;

            var currentStreak = CalculateCurrentStreak(userProgress);
            var longestStreak = CalculateLongestStreak(userProgress);

            var status = userProgress.IsChallengeCompleted() ? "Completed" 
                       : userProgress.CompletedDays.Any() ? "In Progress" 
                       : "Not Started";

            var completionRate = daysActive > 0 
                ? Math.Round((double)userProgress.GetCompletedDaysCount() / daysActive * 100, 1) 
                : 0;

            DateTime? estimatedCompletion = null;
            if (status == "In Progress" && completionRate > 0)
            {
                var remainingDays = 28 - userProgress.GetCompletedDaysCount();
                var avgDaysPerCompletion = daysActive / (double)userProgress.GetCompletedDaysCount();
                estimatedCompletion = DateTime.UtcNow.AddDays(remainingDays * avgDaysPerCompletion);
            }

            return new ChallengeStatsDto
            {
                TotalDaysCompleted = userProgress.GetCompletedDaysCount(),
                TotalDaysAvailable = 28,
                CompletedLevels = completedLevels,
                CurrentLevel = userProgress.CurrentLevel,
                CurrentStreak = currentStreak,
                LongestStreak = longestStreak,
                StartDate = userProgress.StartedAt,
                DaysActive = daysActive,
                CompletionRate = completionRate,
                EstimatedCompletionDate = estimatedCompletion,
                Status = status
            };
        }

        private async Task<UserChallengeProgress> GetOrCreateUserProgressAsync(int userProfileId, int challengeId)
        {
            var userProgress = await _context.UserChallengeProgress
                .FirstOrDefaultAsync(ucp => ucp.UserProfileId == userProfileId && ucp.ChallengeId == challengeId);

            if (userProgress == null)
            {
                userProgress = new UserChallengeProgress
                {
                    UserProfileId = userProfileId,
                    ChallengeId = challengeId,
                    StartedAt = DateTime.UtcNow,
                    IsActive = true,
                    CurrentDay = 1,
                    CurrentLevel = 1,
                    CompletedDaysJson = "[]"
                };

                _context.UserChallengeProgress.Add(userProgress);
                await _context.SaveChangesAsync();
            }

            return userProgress;
        }

        private bool IsLevelUnlocked(int level, UserChallengeProgress userProgress)
        {
            if (level == 1) return true; // Level 1 is always unlocked

            // Check if previous level is completed
            return userProgress.IsLevelCompleted(level - 1);
        }

        private bool IsDayUnlocked(int dayNumber, UserChallengeProgress userProgress)
        {
            if (dayNumber == 1) return true; // Day 1 is always unlocked

            // Check if previous day is completed
            return userProgress.IsDayCompleted(dayNumber - 1);
        }

        private int GetCurrentDay(UserChallengeProgress userProgress)
        {
            if (!userProgress.CompletedDays.Any()) return 1;

            var maxCompletedDay = userProgress.CompletedDays.Max();
            return Math.Min(maxCompletedDay + 1, 28);
        }

        private string GetLevelDescription(int level)
        {
            return level switch
            {
                1 => "Foundation - Building Basic Healthy Habits",
                2 => "Progress - Strengthening Your Routine",
                3 => "Advanced - Challenging Yourself Further", 
                4 => "Mastery - Perfecting Your Lifestyle",
                _ => "Unknown Level"
            };
        }

        private int CalculateCurrentStreak(UserChallengeProgress userProgress)
        {
            if (!userProgress.CompletedDays.Any()) return 0;

            var sortedDays = userProgress.CompletedDays.OrderByDescending(d => d).ToList();
            int streak = 0;
            int expectedDay = sortedDays[0];

            foreach (var day in sortedDays)
            {
                if (day == expectedDay)
                {
                    streak++;
                    expectedDay--;
                }
                else
                {
                    break;
                }
            }

            return streak;
        }

        private int CalculateLongestStreak(UserChallengeProgress userProgress)
        {
            if (!userProgress.CompletedDays.Any()) return 0;

            var sortedDays = userProgress.CompletedDays.OrderBy(d => d).ToList();
            int longestStreak = 1;
            int currentStreak = 1;

            for (int i = 1; i < sortedDays.Count; i++)
            {
                if (sortedDays[i] == sortedDays[i - 1] + 1)
                {
                    currentStreak++;
                    longestStreak = Math.Max(longestStreak, currentStreak);
                }
                else
                {
                    currentStreak = 1;
                }
            }

            return longestStreak;
        }
    }
} 