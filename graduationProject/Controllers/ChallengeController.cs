using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using graduationProject.Interfaces;
using graduationProject.DTOs;
using graduationProject.Extensions;
using graduationProject.Models;
using Microsoft.EntityFrameworkCore;

namespace graduationProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Require authentication for all endpoints
    public class ChallengeController : ControllerBase
    {
        private readonly IChallengeService _challengeService;
        private readonly AppDbContext _context;

        public ChallengeController(IChallengeService challengeService, AppDbContext context)
        {
            _challengeService = challengeService;
            _context = context;
        }

        /// <summary>
        /// Get challenge overview with user progress and level summaries
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<ChallengeOverviewDto>> GetChallengeOverview()
        {
            try
            {
                var userProfileId = await GetUserProfileIdAsync();
                var overview = await _challengeService.GetChallengeOverviewAsync(userProfileId);
                return Ok(overview);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while fetching challenge overview", error = ex.Message });
            }
        }

        /// <summary>
        /// Get detailed information for a specific level
        /// </summary>
        [HttpGet("level/{levelId}")]
        public async Task<ActionResult<ChallengeLevelDetailDto>> GetLevelDetails(int levelId)
        {
            try
            {
                var userProfileId = await GetUserProfileIdAsync();
                var levelDetails = await _challengeService.GetLevelDetailsAsync(userProfileId, levelId);
                return Ok(levelDetails);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while fetching level details", error = ex.Message });
            }
        }

        /// <summary>
        /// Complete a specific day (1-28) in the challenge
        /// </summary>
        [HttpPost("day/{dayNumber}/complete")]
        public async Task<ActionResult<CompleteDayResponseDto>> CompleteDay(int dayNumber)
        {
            try
            {
                var userProfileId = await GetUserProfileIdAsync();
                var result = await _challengeService.CompleteDayAsync(userProfileId, dayNumber);
                return Ok(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while completing the day", error = ex.Message });
            }
        }

        /// <summary>
        /// Get comprehensive challenge statistics for the user
        /// </summary>
        [HttpGet("stats")]
        public async Task<ActionResult<ChallengeStatsDto>> GetChallengeStats()
        {
            try
            {
                var userProfileId = await GetUserProfileIdAsync();
                var stats = await _challengeService.GetChallengeStatsAsync(userProfileId);
                return Ok(stats);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while fetching challenge statistics", error = ex.Message });
            }
        }

        /// <summary>
        /// Get quick challenge status for the user
        /// </summary>
        [HttpGet("status")]
        public async Task<ActionResult> GetQuickStatus()
        {
            try
            {
                var userProfileId = await GetUserProfileIdAsync();
                var overview = await _challengeService.GetChallengeOverviewAsync(userProfileId);
                
                var quickStatus = new
                {
                    IsStarted = overview.IsStarted,
                    CurrentDay = overview.CurrentDay,
                    CurrentLevel = overview.CurrentLevel,
                    CompletedDaysCount = overview.CompletedDaysCount,
                    ProgressPercentage = overview.ProgressPercentage,
                    IsCompleted = overview.IsChallengeCompleted
                };

                return Ok(quickStatus);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while fetching challenge status", error = ex.Message });
            }
        }

        /// <summary>
        /// Helper method to get UserProfileId using the same pattern as other controllers
        /// </summary>
        private async Task<int> GetUserProfileIdAsync()
        {
            // Get authenticated user ID from JWT token using extension method
            var authenticatedUserId = this.GetAuthenticatedUserId();
            if (string.IsNullOrEmpty(authenticatedUserId))
            {
                throw new UnauthorizedAccessException("Invalid or missing authentication token.");
            }

            // Get user profile from database
            var userProfile = await _context.UserProfiles
                .FirstOrDefaultAsync(up => up.AppUserId == authenticatedUserId);
            
            if (userProfile == null)
            {
                throw new UnauthorizedAccessException("User profile not found. Please create a profile first.");
            }

            return userProfile.Id;
        }
    }
} 