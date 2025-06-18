using graduationProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace graduationProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeneralPlansController : ControllerBase
    {
        private readonly IGeneralPlanService _generalPlanService;

        public GeneralPlansController(IGeneralPlanService generalPlanService)
        {
            _generalPlanService = generalPlanService;
        }

        // ===== DIET PLAN ENDPOINTS =====

        /// <summary>
        /// Get all diet plans (Screen 1 - List view)
        /// </summary>
        [HttpGet("diet")]
        public async Task<IActionResult> GetAllDietPlans()
        {
            try
            {
                var plans = await _generalPlanService.GetAllDietPlansAsync();
                return Ok(plans);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while fetching diet plans.", error = ex.Message });
            }
        }

        /// <summary>
        /// Get specific diet plan with meals (Screen 2 - Plan details with breakfast/lunch/dinner tabs)
        /// </summary>
        [HttpGet("diet/{id}")]
        public async Task<IActionResult> GetDietPlanById(int id)
        {
            try
            {
                var plan = await _generalPlanService.GetDietPlanByIdAsync(id);
                if (plan == null)
                    return NotFound(new { message = "Diet plan not found." });

                return Ok(plan);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while fetching the diet plan.", error = ex.Message });
            }
        }

        /// <summary>
        /// Get specific meal details (Screen 3 - Individual meal with ingredients, steps, benefits)
        /// </summary>
        [HttpGet("diet/meal/{mealId}")]
        public async Task<IActionResult> GetMealDetail(int mealId)
        {
            try
            {
                var meal = await _generalPlanService.GetMealDetailAsync(mealId);
                if (meal == null)
                    return NotFound(new { message = "Meal not found." });

                return Ok(meal);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while fetching the meal details.", error = ex.Message });
            }
        }

        /// <summary>
        /// Get all diet categories
        /// </summary>
        [HttpGet("diet/categories")]
        public async Task<IActionResult> GetDietCategories()
        {
            try
            {
                var categories = await _generalPlanService.GetDietCategoriesAsync();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while fetching diet categories.", error = ex.Message });
            }
        }

        /// <summary>
        /// Get ALL diet data in one endpoint (Overview endpoint)
        /// </summary>
        [HttpGet("diet/all")]
        public async Task<IActionResult> GetAllDietData()
        {
            try
            {
                var allData = await _generalPlanService.GetAllDietDataAsync();
                return Ok(allData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while fetching all diet data.", error = ex.Message });
            }
        }

        // ===== WORKOUT PLAN ENDPOINTS =====

        /// <summary>
        /// Get all workout plans (Screen 1 - List view)
        /// </summary>
        [HttpGet("workout")]
        public async Task<IActionResult> GetAllWorkoutPlans()
        {
            try
            {
                var plans = await _generalPlanService.GetAllWorkoutPlansAsync();
                return Ok(plans);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while fetching workout plans.", error = ex.Message });
            }
        }

        /// <summary>
        /// Get specific workout plan with days (Screen 2 - Plan details with day breakdown)
        /// </summary>
        [HttpGet("workout/{id}")]
        public async Task<IActionResult> GetWorkoutPlanById(int id)
        {
            try
            {
                var plan = await _generalPlanService.GetWorkoutPlanByIdAsync(id);
                if (plan == null)
                    return NotFound(new { message = "Workout plan not found." });

                return Ok(plan);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while fetching the workout plan.", error = ex.Message });
            }
        }

        /// <summary>
        /// Get specific exercise details (Screen 3 - Individual exercise with instructions, tips, benefits)
        /// </summary>
        [HttpGet("workout/exercise/{exerciseId}")]
        public async Task<IActionResult> GetExerciseDetail(int exerciseId)
        {
            try
            {
                var exercise = await _generalPlanService.GetExerciseDetailAsync(exerciseId);
                if (exercise == null)
                    return NotFound(new { message = "Exercise not found." });

                return Ok(exercise);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while fetching the exercise details.", error = ex.Message });
            }
        }

        /// <summary>
        /// Get all workout categories
        /// </summary>
        [HttpGet("workout/categories")]
        public async Task<IActionResult> GetWorkoutCategories()
        {
            try
            {
                var categories = await _generalPlanService.GetWorkoutCategoriesAsync();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while fetching workout categories.", error = ex.Message });
            }
        }

        /// <summary>
        /// Get ALL workout data in one endpoint (Overview endpoint)
        /// </summary>
        [HttpGet("workout/all")]
        public async Task<IActionResult> GetAllWorkoutData()
        {
            try
            {
                var allData = await _generalPlanService.GetAllWorkoutDataAsync();
                return Ok(allData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while fetching all workout data.", error = ex.Message });
            }
        }

        // ===== INITIALIZATION ENDPOINT =====

        /// <summary>
        /// Initialize seed data for general plans (Admin use)
        /// </summary>
        [HttpPost("initialize")]
        public async Task<IActionResult> InitializeData()
        {
            try
            {
                await _generalPlanService.InitializeDataAsync();
                return Ok(new { message = "General plans data initialized successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while initializing data.", error = ex.Message });
            }
        }
    }
} 