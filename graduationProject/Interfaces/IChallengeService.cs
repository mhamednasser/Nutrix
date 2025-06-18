using graduationProject.DTOs;

namespace graduationProject.Interfaces
{
    public interface IChallengeService
    {
        Task<ChallengeOverviewDto> GetChallengeOverviewAsync(int userProfileId);
        Task<ChallengeLevelDetailDto> GetLevelDetailsAsync(int userProfileId, int levelId);
        Task<CompleteDayResponseDto> CompleteDayAsync(int userProfileId, int dayNumber);
        Task<ChallengeStatsDto> GetChallengeStatsAsync(int userProfileId);
    }
} 