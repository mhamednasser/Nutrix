using graduationProject.Models;
using System.Security.Claims;

namespace graduationProject.Interfaces
{
    public interface IJwtService
    {
        Task<string> GenerateTokenAsync(AppUser user);
        ClaimsPrincipal? ValidateToken(string token);
        Task<string> GenerateRefreshTokenAsync();
    }
} 