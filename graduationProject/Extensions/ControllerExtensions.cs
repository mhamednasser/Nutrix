using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace graduationProject.Extensions
{
    public static class ControllerExtensions
    {
        /// <summary>
        /// Gets the authenticated user's ID from the JWT token
        /// </summary>
        /// <param name="controller">The controller instance</param>
        /// <returns>The user ID from the token, or null if not authenticated</returns>
        public static string? GetAuthenticatedUserId(this ControllerBase controller)
        {
            // Try both the standard ClaimTypes.NameIdentifier and the full URI format
            var userId = controller.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                // Fallback to the full URI format in case claim mapping didn't work
                userId = controller.User?.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            }
            return userId;
        }

        /// <summary>
        /// Gets the authenticated user's username from the JWT token
        /// </summary>
        /// <param name="controller">The controller instance</param>
        /// <returns>The username from the token, or null if not authenticated</returns>
        public static string? GetAuthenticatedUserName(this ControllerBase controller)
        {
            // Try both the standard ClaimTypes.Name and the full URI format
            var userName = controller.User?.FindFirst(ClaimTypes.Name)?.Value;
            if (string.IsNullOrEmpty(userName))
            {
                // Fallback to the full URI format
                userName = controller.User?.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value;
            }
            return userName;
        }

        /// <summary>
        /// Gets the authenticated user's email from the JWT token
        /// </summary>
        /// <param name="controller">The controller instance</param>
        /// <returns>The email from the token, or null if not authenticated</returns>
        public static string? GetAuthenticatedUserEmail(this ControllerBase controller)
        {
            // Try both the standard ClaimTypes.Email and the full URI format
            var email = controller.User?.FindFirst(ClaimTypes.Email)?.Value;
            if (string.IsNullOrEmpty(email))
            {
                // Fallback to the full URI format
                email = controller.User?.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
            }
            return email;
        }

        /// <summary>
        /// Validates that the authenticated user ID matches the requested user ID
        /// </summary>
        /// <param name="controller">The controller instance</param>
        /// <param name="requestedUserId">The user ID being requested</param>
        /// <returns>True if the authenticated user matches the requested user, false otherwise</returns>
        public static bool IsAuthorizedForUser(this ControllerBase controller, string requestedUserId)
        {
            var authenticatedUserId = controller.GetAuthenticatedUserId();
            return !string.IsNullOrEmpty(authenticatedUserId) && 
                   authenticatedUserId.Equals(requestedUserId, StringComparison.OrdinalIgnoreCase);
        }
    }
} 