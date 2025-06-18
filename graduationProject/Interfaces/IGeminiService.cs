using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace graduationProject.Interfaces
{
    public interface IGeminiService
    {
        Task<string> DetectFoodAsync(IFormFile image);
    }
} 