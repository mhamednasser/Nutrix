using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using graduationProject.Models;
using graduationProject.Extensions;

namespace graduationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // 🔒 Require authentication for all endpoints
    public class ProfileController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProfileController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/profile - Retrieve authenticated user's full profile with plans
        [HttpGet]
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
                return NotFound("User profile not found.");

            // Fetch generated plans for the authenticated user
            var workoutPlans = await _context.StructuredWorkoutPlans
                .Where(w => w.UserProfileId == userProfile.Id)
                .OrderByDescending(w => w.CreatedAt)
                .ToListAsync();
            
            var dietPlans = await _context.StructuredDietPlans
                .Where(d => d.UserProfileId == userProfile.Id)
                .OrderByDescending(d => d.CreatedAt)
                .ToListAsync();

            var profile = new
            {
                UserProfile = userProfile,
                WorkoutPlans = workoutPlans,
                DietPlans = dietPlans
            };

            return Ok(profile);
        }

        // GET: api/profile/user/{userId} - Admin endpoint for accessing specific user profile (with security check)
        [HttpGet("user/{userId}")]
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
                return NotFound("User profile not found.");

            // Fetch generated plans for the user
            var workoutPlans = await _context.StructuredWorkoutPlans
                .Where(w => w.UserProfileId == userProfile.Id)
                .OrderByDescending(w => w.CreatedAt)
                .ToListAsync();
            
            var dietPlans = await _context.StructuredDietPlans
                .Where(d => d.UserProfileId == userProfile.Id)
                .OrderByDescending(d => d.CreatedAt)
                .ToListAsync();

            var profile = new
            {
                UserProfile = userProfile,
                WorkoutPlans = workoutPlans,
                DietPlans = dietPlans
            };

            return Ok(profile);
        }
    }
}
