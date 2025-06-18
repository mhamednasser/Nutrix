using graduationProject.Interfaces;
using graduationProject.Models;
using graduationProject.DTOs;
using graduationProject.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace graduationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // 🔒 Require authentication for all endpoints
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IPlanGenerationService _planGenerationService;
        private readonly UserManager<AppUser> _userManager;

        public UserController(AppDbContext context, IPlanGenerationService planGenerationService, UserManager<AppUser> userManager)
        {
            _context = context;
            _planGenerationService = planGenerationService;
            _userManager = userManager;
        }

        // POST: api/user/profile - Creates a new user profile for the authenticated user
        [HttpPost("profile")]
        public async Task<IActionResult> CreateUserProfile([FromBody] CreateUserProfileDto userProfileDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // 🔐 Get authenticated user ID from JWT token
            var authenticatedUserId = this.GetAuthenticatedUserId();
            if (string.IsNullOrEmpty(authenticatedUserId))
            {
                return Unauthorized("Invalid or missing authentication token.");
            }

            // Use authenticated user ID (removed DTO user ID check since field was removed for security)
            var userId = authenticatedUserId;

            // Check if AppUser exists
            var appUser = await _userManager.FindByIdAsync(userId);
            if (appUser == null)
            {
                return BadRequest("User not found.");
            }

            // Check if profile already exists
            var existingProfile = await _context.UserProfiles
                .FirstOrDefaultAsync(up => up.AppUserId == userId);
            if (existingProfile != null)
            {
                return BadRequest("User profile already exists.");
            }

            // Create new user profile
            var userProfile = new UserProfile
            {
                AppUserId = userId,
                Age = userProfileDto.Age,
                Gender = userProfileDto.Gender,
                Height = userProfileDto.Height,
                Weight = userProfileDto.Weight,
                FitnessLevel = userProfileDto.FitnessLevel,
                WeeklyWorkoutDays = userProfileDto.WeeklyWorkoutDays,
                WorkoutDuration = userProfileDto.WorkoutDuration,
                Goal = userProfileDto.Goal,
                DietaryRestrictions = userProfileDto.DietaryRestrictions,
                PreferredDiet = userProfileDto.PreferredDiet,
                MedicalConditions = userProfileDto.MedicalConditions
            };

            _context.UserProfiles.Add(userProfile);
            await _context.SaveChangesAsync();

            // Generate and save the diet plan
            var dietPlan = await _planGenerationService.GenerateDietPlanAsync(userProfile);
            _context.StructuredDietPlans.Add(dietPlan);

            // Generate and save the workout plan
            var workoutPlan = await _planGenerationService.GenerateWorkoutPlanAsync(userProfile);
            _context.StructuredWorkoutPlans.Add(workoutPlan);

            // Save the plans to the database
            await _context.SaveChangesAsync();

            return Ok(new { UserProfile = userProfile, DietPlan = dietPlan, WorkoutPlan = workoutPlan });
        }

        // GET: api/user/profile - Retrieves the authenticated user's profile
        [HttpGet("profile")]
        public async Task<IActionResult> GetUserProfile()
        {
            // 🔐 Get authenticated user ID from JWT token
            var authenticatedUserId = this.GetAuthenticatedUserId();
            if (string.IsNullOrEmpty(authenticatedUserId))
            {
                return Unauthorized("Invalid or missing authentication token.");
            }

            var userProfile = await _context.UserProfiles
                .Include(up => up.AppUser)
                .FirstOrDefaultAsync(up => up.AppUserId == authenticatedUserId);

            if (userProfile == null)
            {
                return NotFound("User profile not found.");
            }

            return Ok(userProfile);
        }

        // GET: api/user/profile/{userId} - Admin endpoint to get any user's profile (if needed)
        [HttpGet("profile/{userId}")]
        public async Task<IActionResult> GetUserProfileById(string userId)
        {
            // 🔐 Get authenticated user ID from JWT token
            var authenticatedUserId = this.GetAuthenticatedUserId();
            if (string.IsNullOrEmpty(authenticatedUserId))
            {
                return Unauthorized("Invalid or missing authentication token.");
            }

            // 🔒 Security: Users can only access their own profiles
            if (!this.IsAuthorizedForUser(userId))
            {
                return Forbid("You can only access your own profile.");
            }

            var userProfile = await _context.UserProfiles
                .Include(up => up.AppUser)
                .FirstOrDefaultAsync(up => up.AppUserId == userId);

            if (userProfile == null)
            {
                return NotFound("User profile not found.");
            }

            return Ok(userProfile);
        }

        // PUT: api/user/profile - Updates the authenticated user's profile
        [HttpPut("profile")]
        public async Task<IActionResult> UpdateUserProfile([FromBody] UpdateUserProfileDto updatedProfileDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // 🔐 Get authenticated user ID from JWT token
            var authenticatedUserId = this.GetAuthenticatedUserId();
            if (string.IsNullOrEmpty(authenticatedUserId))
            {
                return Unauthorized("Invalid or missing authentication token.");
            }

            var userProfile = await _context.UserProfiles
                .FirstOrDefaultAsync(up => up.AppUserId == authenticatedUserId);
            if (userProfile == null)
            {
                return NotFound("User profile not found.");
            }

            // Update user profile data
            userProfile.Age = updatedProfileDto.Age;
            userProfile.Gender = updatedProfileDto.Gender;
            userProfile.Height = updatedProfileDto.Height;
            userProfile.Weight = updatedProfileDto.Weight;
            userProfile.FitnessLevel = updatedProfileDto.FitnessLevel;
            userProfile.WeeklyWorkoutDays = updatedProfileDto.WeeklyWorkoutDays;
            userProfile.WorkoutDuration = updatedProfileDto.WorkoutDuration;
            userProfile.Goal = updatedProfileDto.Goal;
            userProfile.DietaryRestrictions = updatedProfileDto.DietaryRestrictions;
            userProfile.PreferredDiet = updatedProfileDto.PreferredDiet;
            userProfile.MedicalConditions = updatedProfileDto.MedicalConditions;
            userProfile.UpdatedAt = DateTime.UtcNow;

            // Regenerate both diet and workout plans
            var dietPlan = await _planGenerationService.GenerateDietPlanAsync(userProfile);
            var workoutPlan = await _planGenerationService.GenerateWorkoutPlanAsync(userProfile);

            // Update or add diet plan
            var existingDietPlan = await _context.StructuredDietPlans
                .FirstOrDefaultAsync(p => p.UserProfileId == userProfile.Id);
            if (existingDietPlan != null)
            {
                existingDietPlan.PlanJson = dietPlan.PlanJson;
                existingDietPlan.UpdatedAt = DateTime.UtcNow;
                _context.StructuredDietPlans.Update(existingDietPlan);
            }
            else
            {
                _context.StructuredDietPlans.Add(dietPlan);
            }

            // Update or add workout plan
            var existingWorkoutPlan = await _context.StructuredWorkoutPlans
                .FirstOrDefaultAsync(p => p.UserProfileId == userProfile.Id);
            if (existingWorkoutPlan != null)
            {
                existingWorkoutPlan.PlanJson = workoutPlan.PlanJson;
                existingWorkoutPlan.UpdatedAt = DateTime.UtcNow;
                _context.StructuredWorkoutPlans.Update(existingWorkoutPlan);
            }
            else
            {
                _context.StructuredWorkoutPlans.Add(workoutPlan);
            }

            await _context.SaveChangesAsync();

            return Ok(new { UserProfile = userProfile, DietPlan = dietPlan, WorkoutPlan = workoutPlan });
        }

        // DELETE: api/user/profile - Deletes the authenticated user's profile
        [HttpDelete("profile")]
        public async Task<IActionResult> DeleteUserProfile()
        {
            // 🔐 Get authenticated user ID from JWT token
            var authenticatedUserId = this.GetAuthenticatedUserId();
            if (string.IsNullOrEmpty(authenticatedUserId))
            {
                return Unauthorized("Invalid or missing authentication token.");
            }

            var userProfile = await _context.UserProfiles
                .FirstOrDefaultAsync(up => up.AppUserId == authenticatedUserId);
            if (userProfile == null)
            {
                return NotFound("User profile not found.");
            }

            // Delete associated diet plans
            var dietPlans = _context.StructuredDietPlans.Where(p => p.UserProfileId == userProfile.Id);
            _context.StructuredDietPlans.RemoveRange(dietPlans);

            // Delete associated workout plans
            var workoutPlans = _context.StructuredWorkoutPlans.Where(p => p.UserProfileId == userProfile.Id);
            _context.StructuredWorkoutPlans.RemoveRange(workoutPlans);

            // Delete the user profile
            _context.UserProfiles.Remove(userProfile);
            await _context.SaveChangesAsync();

            return Ok("User profile and associated plans deleted successfully.");
        }
    }
}
