using graduationProject.DTOs;
using graduationProject.Models;
using System.Threading.Tasks;

namespace graduationProject.Interfaces
{
    public interface IPlanGenerationService
    {
        Task<StructuredDietPlan> GenerateDietPlanAsync(UserProfile userProfile);

        Task<StructuredWorkoutPlan> GenerateWorkoutPlanAsync(UserProfile userProfile);
    }
}