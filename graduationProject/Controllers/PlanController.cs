using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using graduationProject.Interfaces;
using graduationProject.Models;
using graduationProject.Extensions;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace graduationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // 🔒 Require authentication for all endpoints
    public class PlanController : ControllerBase
    {
        private readonly IPlanGenerationService _planGenerationService;
        private readonly AppDbContext _context;

        public PlanController(IPlanGenerationService planGenerationService, AppDbContext context)
        {
            _planGenerationService = planGenerationService;
            _context = context;
        }

        // POST: api/plan/diet - Generate/regenerate diet plan for authenticated user
        [HttpPost("diet")]
        public async Task<IActionResult> GenerateDietPlan()
        {
            // 🔐 Get authenticated user ID from JWT token
            var authenticatedUserId = this.GetAuthenticatedUserId();
            if (string.IsNullOrEmpty(authenticatedUserId))
            {
                return Unauthorized("Invalid or missing authentication token.");
            }

            // Get user profile
            var userProfile = await _context.UserProfiles
                .FirstOrDefaultAsync(up => up.AppUserId == authenticatedUserId);
            if (userProfile == null)
            {
                return NotFound("User profile not found. Please create a profile first.");
            }

            try
            {
                // Generate the diet plan
                var structuredDietPlan = await _planGenerationService.GenerateDietPlanAsync(userProfile);

                // Validate the AI response has minimum required structure
                if (string.IsNullOrEmpty(structuredDietPlan.PlanJson))
                {
                    return BadRequest("Failed to generate a valid diet plan.");
                }

                // Basic validation - ensure it's valid JSON and has key fields
                try
                {
                    var jsonDoc = JsonDocument.Parse(structuredDietPlan.PlanJson);
                    var root = jsonDoc.RootElement;
                    
                    // Check for minimum required fields
                    if (!root.TryGetProperty("duration", out _) || 
                        !root.TryGetProperty("daily_plans", out _))
                    {
                        return BadRequest("Generated plan missing required fields.");
                    }
                }
                catch (JsonException)
                {
                    return BadRequest("Generated plan is not valid JSON.");
                }

                // Check if a diet plan already exists for this user
                var existingPlan = await _context.StructuredDietPlans
                    .FirstOrDefaultAsync(p => p.UserProfileId == userProfile.Id);

                if (existingPlan != null)
                {
                    // Update existing plan
                    existingPlan.PlanJson = structuredDietPlan.PlanJson;
                    existingPlan.UpdatedAt = DateTime.UtcNow;
                    _context.StructuredDietPlans.Update(existingPlan);
                }
                else
                {
                    // Create new plan
                    _context.StructuredDietPlans.Add(structuredDietPlan);
                }

                await _context.SaveChangesAsync();

                return Ok(new
                {
                    Message = "Diet plan generated successfully",
                    Plan = structuredDietPlan.PlanData, // Clean, consistent structured data
                    CreatedAt = structuredDietPlan.CreatedAt,
                    UpdatedAt = structuredDietPlan.UpdatedAt
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error generating diet plan", Error = ex.Message });
            }
        }

        // GET: api/plan/diet - Get diet plan for authenticated user
        [HttpGet("diet")]
        public async Task<IActionResult> GetDietPlan()
        {
            // 🔐 Get authenticated user ID from JWT token
            var authenticatedUserId = this.GetAuthenticatedUserId();
            if (string.IsNullOrEmpty(authenticatedUserId))
            {
                return Unauthorized("Invalid or missing authentication token.");
            }

            // Get user profile
            var userProfile = await _context.UserProfiles
                .FirstOrDefaultAsync(up => up.AppUserId == authenticatedUserId);
            if (userProfile == null)
            {
                return NotFound("User profile not found.");
            }

            var dietPlan = await _context.StructuredDietPlans
                .FirstOrDefaultAsync(p => p.UserProfileId == userProfile.Id);
            if (dietPlan == null)
            {
                return NotFound("No diet plan found. Generate a plan first.");
            }

            return Ok(new
            {
                Plan = dietPlan.PlanData,
                CreatedAt = dietPlan.CreatedAt,
                UpdatedAt = dietPlan.UpdatedAt
            });
        }

        // DELETE: api/plan/diet - Delete diet plan for authenticated user
        [HttpDelete("diet")]
        public async Task<IActionResult> DeleteDietPlan()
        {
            // 🔐 Get authenticated user ID from JWT token
            var authenticatedUserId = this.GetAuthenticatedUserId();
            if (string.IsNullOrEmpty(authenticatedUserId))
            {
                return Unauthorized("Invalid or missing authentication token.");
            }

            // Get user profile
            var userProfile = await _context.UserProfiles
                .FirstOrDefaultAsync(up => up.AppUserId == authenticatedUserId);
            if (userProfile == null)
            {
                return NotFound("User profile not found.");
            }

            var dietPlan = await _context.StructuredDietPlans
                .FirstOrDefaultAsync(p => p.UserProfileId == userProfile.Id);
            if (dietPlan == null)
            {
                return NotFound("Diet plan not found.");
            }

            _context.StructuredDietPlans.Remove(dietPlan);
            await _context.SaveChangesAsync();

            return Ok("Diet plan deleted successfully.");
        }

        // POST: api/plan/workout - Generate/regenerate workout plan for authenticated user
        [HttpPost("workout")]
        public async Task<IActionResult> GenerateWorkoutPlan()
        {
            // 🔐 Get authenticated user ID from JWT token
            var authenticatedUserId = this.GetAuthenticatedUserId();
            if (string.IsNullOrEmpty(authenticatedUserId))
            {
                return Unauthorized("Invalid or missing authentication token.");
            }

            // Get user profile
            var userProfile = await _context.UserProfiles
                .FirstOrDefaultAsync(up => up.AppUserId == authenticatedUserId);
            if (userProfile == null)
            {
                return NotFound("User profile not found. Please create a profile first.");
            }

            try
            {
                // Generate the workout plan
                var structuredWorkoutPlan = await _planGenerationService.GenerateWorkoutPlanAsync(userProfile);

                // Validate the AI response
                if (string.IsNullOrEmpty(structuredWorkoutPlan.PlanJson))
                {
                    return BadRequest("Failed to generate a valid workout plan.");
                }

                // Check if a workout plan already exists for this user
                var existingPlan = await _context.StructuredWorkoutPlans
                    .FirstOrDefaultAsync(p => p.UserProfileId == userProfile.Id);

                if (existingPlan != null)
                {
                    // Update existing plan
                    existingPlan.PlanJson = structuredWorkoutPlan.PlanJson;
                    existingPlan.UpdatedAt = DateTime.UtcNow;
                    _context.StructuredWorkoutPlans.Update(existingPlan);
                }
                else
                {
                    // Create new plan
                    _context.StructuredWorkoutPlans.Add(structuredWorkoutPlan);
                }

                await _context.SaveChangesAsync();

                return Ok(new
                {
                    Message = "Workout plan generated successfully",
                    Plan = structuredWorkoutPlan.PlanData,
                    CreatedAt = structuredWorkoutPlan.CreatedAt,
                    UpdatedAt = structuredWorkoutPlan.UpdatedAt
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error generating workout plan", Error = ex.Message });
            }
        }

        // GET: api/plan/workout - Get workout plan for authenticated user
        [HttpGet("workout")]
        public async Task<IActionResult> GetWorkoutPlan()
        {
            // 🔐 Get authenticated user ID from JWT token
            var authenticatedUserId = this.GetAuthenticatedUserId();
            if (string.IsNullOrEmpty(authenticatedUserId))
            {
                return Unauthorized("Invalid or missing authentication token.");
            }

            // Get user profile
            var userProfile = await _context.UserProfiles
                .FirstOrDefaultAsync(up => up.AppUserId == authenticatedUserId);
            if (userProfile == null)
            {
                return NotFound("User profile not found.");
            }

            var workoutPlan = await _context.StructuredWorkoutPlans
                .FirstOrDefaultAsync(p => p.UserProfileId == userProfile.Id);
            if (workoutPlan == null)
            {
                return NotFound("No workout plan found. Generate a plan first.");
            }

            return Ok(new
            {
                Plan = workoutPlan.PlanData,
                CreatedAt = workoutPlan.CreatedAt,
                UpdatedAt = workoutPlan.UpdatedAt
            });
        }

        // DELETE: api/plan/workout - Delete workout plan for authenticated user
        [HttpDelete("workout")]
        public async Task<IActionResult> DeleteWorkoutPlan()
        {
            // 🔐 Get authenticated user ID from JWT token
            var authenticatedUserId = this.GetAuthenticatedUserId();
            if (string.IsNullOrEmpty(authenticatedUserId))
            {
                return Unauthorized("Invalid or missing authentication token.");
            }

            // Get user profile
            var userProfile = await _context.UserProfiles
                .FirstOrDefaultAsync(up => up.AppUserId == authenticatedUserId);
            if (userProfile == null)
            {
                return NotFound("User profile not found.");
            }

            var workoutPlan = await _context.StructuredWorkoutPlans
                .FirstOrDefaultAsync(p => p.UserProfileId == userProfile.Id);
            if (workoutPlan == null)
            {
                return NotFound("Workout plan not found.");
            }

            _context.StructuredWorkoutPlans.Remove(workoutPlan);
            await _context.SaveChangesAsync();

            return Ok("Workout plan deleted successfully.");
        }

        // GET: api/plan/all - Get all plans for authenticated user
        [HttpGet("all")]
        public async Task<IActionResult> GetAllPlans()
        {
            // 🔐 Get authenticated user ID from JWT token
            var authenticatedUserId = this.GetAuthenticatedUserId();
            if (string.IsNullOrEmpty(authenticatedUserId))
            {
                return Unauthorized("Invalid or missing authentication token.");
            }

            // Get user profile
            var userProfile = await _context.UserProfiles
                .FirstOrDefaultAsync(up => up.AppUserId == authenticatedUserId);
            if (userProfile == null)
            {
                return NotFound("User profile not found.");
            }

            var dietPlan = await _context.StructuredDietPlans
                .FirstOrDefaultAsync(p => p.UserProfileId == userProfile.Id);

            var workoutPlan = await _context.StructuredWorkoutPlans
                .FirstOrDefaultAsync(p => p.UserProfileId == userProfile.Id);

            return Ok(new
            {
                DietPlan = dietPlan != null ? new
                {
                    Plan = dietPlan.PlanData,
                    CreatedAt = dietPlan.CreatedAt,
                    UpdatedAt = dietPlan.UpdatedAt
                } : null,
                WorkoutPlan = workoutPlan != null ? new
                {
                    Plan = workoutPlan.PlanData,
                    CreatedAt = workoutPlan.CreatedAt,
                    UpdatedAt = workoutPlan.UpdatedAt
                } : null
            });
        }
    }
}