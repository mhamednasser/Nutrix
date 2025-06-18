using graduationProject.Models;

namespace graduationProject.Repositories
{
    public interface IGeneralPlanRepository
    {
        // Diet Plan Methods
        Task<IEnumerable<GeneralDietPlan>> GetAllDietPlansAsync();
        Task<GeneralDietPlan?> GetDietPlanByIdAsync(int id);
        Task<IEnumerable<string>> GetDietCategoriesAsync();
        
        // Workout Plan Methods
        Task<IEnumerable<GeneralWorkoutPlan>> GetAllWorkoutPlansAsync();
        Task<GeneralWorkoutPlan?> GetWorkoutPlanByIdAsync(int id);
        Task<IEnumerable<string>> GetWorkoutCategoriesAsync();
        
        // Data seeding methods
        Task SeedDietPlansAsync();
        Task SeedWorkoutPlansAsync();
        Task<bool> HasDietPlansAsync();
        Task<bool> HasWorkoutPlansAsync();
    }
} 