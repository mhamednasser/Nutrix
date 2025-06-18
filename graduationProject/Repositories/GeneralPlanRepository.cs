using graduationProject.Models;
using graduationProject.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace graduationProject.Repositories
{
    public class GeneralPlanRepository : IGeneralPlanRepository
    {
        private readonly AppDbContext _context;

        public GeneralPlanRepository(AppDbContext context)
        {
            _context = context;
        }

        // Diet Plan Methods
        public async Task<IEnumerable<GeneralDietPlan>> GetAllDietPlansAsync()
        {
            return await _context.GeneralDietPlans
                .Where(p => p.IsActive)
                .OrderBy(p => p.Id)
                .ToListAsync();
        }

        public async Task<GeneralDietPlan?> GetDietPlanByIdAsync(int id)
        {
            return await _context.GeneralDietPlans
                .FirstOrDefaultAsync(p => p.Id == id && p.IsActive);
        }

        public async Task<IEnumerable<string>> GetDietCategoriesAsync()
        {
            return await _context.GeneralDietPlans
                .Where(p => p.IsActive)
                .Select(p => p.Category)
                .Distinct()
                .ToListAsync();
        }

        // Workout Plan Methods
        public async Task<IEnumerable<GeneralWorkoutPlan>> GetAllWorkoutPlansAsync()
        {
            return await _context.GeneralWorkoutPlans
                .Where(p => p.IsActive)
                .OrderBy(p => p.Id)
                .ToListAsync();
        }

        public async Task<GeneralWorkoutPlan?> GetWorkoutPlanByIdAsync(int id)
        {
            return await _context.GeneralWorkoutPlans
                .FirstOrDefaultAsync(p => p.Id == id && p.IsActive);
        }

        public async Task<IEnumerable<string>> GetWorkoutCategoriesAsync()
        {
            return await _context.GeneralWorkoutPlans
                .Where(p => p.IsActive)
                .Select(p => p.Category)
                .Distinct()
                .ToListAsync();
        }

        // Data checking methods
        public async Task<bool> HasDietPlansAsync()
        {
            return await _context.GeneralDietPlans.AnyAsync();
        }

        public async Task<bool> HasWorkoutPlansAsync()
        {
            return await _context.GeneralWorkoutPlans.AnyAsync();
        }

        // Seed Data Methods
        public async Task SeedDietPlansAsync()
        {
            if (await HasDietPlansAsync()) return;

            var dietPlans = DietPlanSeedData.GetDietPlans();
            _context.GeneralDietPlans.AddRange(dietPlans);
            await _context.SaveChangesAsync();
        }

        public async Task SeedWorkoutPlansAsync()
        {
            if (await HasWorkoutPlansAsync()) return;

            var workoutPlans = WorkoutPlanSeedData.GetWorkoutPlans();
            _context.GeneralWorkoutPlans.AddRange(workoutPlans);
            await _context.SaveChangesAsync();
        }
    }
} 