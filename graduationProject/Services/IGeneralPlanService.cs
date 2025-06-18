using graduationProject.DTOs;

namespace graduationProject.Services
{
    public interface IGeneralPlanService
    {
        // Diet Plan Services
        Task<IEnumerable<GeneralDietPlanListDto>> GetAllDietPlansAsync();
        Task<GeneralDietPlanDetailDto?> GetDietPlanByIdAsync(int id);
        Task<MealDetailDto?> GetMealDetailAsync(int mealId);
        Task<IEnumerable<string>> GetDietCategoriesAsync();
        Task<AllDietPlansDto> GetAllDietDataAsync();
        
        // Workout Plan Services
        Task<IEnumerable<GeneralWorkoutPlanListDto>> GetAllWorkoutPlansAsync();
        Task<GeneralWorkoutPlanDetailDto?> GetWorkoutPlanByIdAsync(int id);
        Task<ExerciseDetailDto?> GetExerciseDetailAsync(int exerciseId);
        Task<IEnumerable<string>> GetWorkoutCategoriesAsync();
        Task<AllWorkoutPlansDto> GetAllWorkoutDataAsync();
        
        // Data initialization
        Task InitializeDataAsync();
    }
} 