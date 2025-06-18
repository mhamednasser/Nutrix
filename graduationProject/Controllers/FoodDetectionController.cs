using graduationProject.Models;
using graduationProject.Services;
using graduationProject.Extensions;
using graduationProject.Interfaces;
using graduationProject.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Collections.Generic;

namespace graduationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // 🔒 Require authentication for all endpoints
    public class FoodDetectionController : ControllerBase
    {
        private readonly PythonApiService _pythonApiService;
        private readonly IGeminiService _geminiService;
        private readonly AppDbContext _dbContext;

        public FoodDetectionController(PythonApiService pythonApiService, IGeminiService geminiService, AppDbContext dbContext)
        {
            _pythonApiService = pythonApiService;
            _geminiService = geminiService;
            _dbContext = dbContext;
        }

        // =====================================================================
        // LOCAL AI FOOD DETECTION FEATURE (Original Python API)
        // =====================================================================

        // POST: Upload image, call the Python API, and save nutritional data for authenticated user
        [HttpPost("scan")]
        public async Task<IActionResult> ScanFood(IFormFile image)
        {
            // Validate the image file
            if (image == null || image.Length == 0)
            {
                return BadRequest("No image uploaded.");
            }

            if (!image.ContentType.StartsWith("image/"))
            {
                return BadRequest("Uploaded file is not an image.");
            }

            // 🔐 Get authenticated user ID from JWT token
            var authenticatedUserId = this.GetAuthenticatedUserId();
            if (string.IsNullOrEmpty(authenticatedUserId))
            {
                return Unauthorized("Invalid or missing authentication token.");
            }

            // Get user profile for the authenticated user
            var userProfile = await _dbContext.UserProfiles
                .FirstOrDefaultAsync(up => up.AppUserId == authenticatedUserId);
            if (userProfile == null)
            {
                return NotFound("User profile not found. Please create a profile first.");
            }

            try
            {
                // Call the Python API to get nutritional data as a raw JSON string
                var rawJson = await _pythonApiService.PredictNutritionalInfoAsync(image);

                // Deserialize the raw JSON string into a structured object (NutritionalInfoWrapper)
                var nutritionalInfoWrapper = JsonSerializer.Deserialize<NutritionalInfoWrapper>(rawJson);

                // Check for null deserialization
                if (nutritionalInfoWrapper?.NutritionalInfo == null)
                {
                    return StatusCode(500, "Failed to parse nutritional information from local AI service.");
                }

                // Create a new NutritionalInfo object and store the raw JSON string
                var nutritionalInfo = new NutritionalInfo
                {
                    JsonData = rawJson,  // Save the raw JSON data (as a string)
                    UserProfileId = userProfile.Id  // Link to UserProfile instead of old User
                };

                // Save the data to the database
                _dbContext.NutritionalInfos.Add(nutritionalInfo);
                await _dbContext.SaveChangesAsync();

                // Return the deserialized data as JSON in the response
                return CreatedAtAction(nameof(GetLocalNutritionalInfo), new { id = nutritionalInfo.Id }, new
                {
                    id = nutritionalInfo.Id,
                    provider = "local",
                    nutritional_info = nutritionalInfoWrapper.NutritionalInfo
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: Retrieve LOCAL AI nutritional data by ID for authenticated user
        [HttpGet("local/{id}")]
        public async Task<IActionResult> GetLocalNutritionalInfo(int id)
        {
            // 🔐 Get authenticated user ID from JWT token
            var authenticatedUserId = this.GetAuthenticatedUserId();
            if (string.IsNullOrEmpty(authenticatedUserId))
            {
                return Unauthorized("Invalid or missing authentication token.");
            }

            // Get user profile for the authenticated user
            var userProfile = await _dbContext.UserProfiles
                .FirstOrDefaultAsync(up => up.AppUserId == authenticatedUserId);
            if (userProfile == null)
            {
                return NotFound("User profile not found.");
            }

            var nutritionalInfo = await _dbContext.NutritionalInfos
                .FirstOrDefaultAsync(n => n.Id == id && n.UserProfileId == userProfile.Id);

            if (nutritionalInfo == null)
            {
                return NotFound("Local nutritional information not found.");
            }

            try
            {
                // Deserialize as original local format
                var nutritionalInfoWrapper = JsonSerializer.Deserialize<NutritionalInfoWrapper>(nutritionalInfo.JsonData);
                return Ok(new 
                { 
                    id = nutritionalInfo.Id,
                    provider = "local", 
                    data = nutritionalInfoWrapper 
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error processing local nutritional data: {ex.Message}");
            }
        }

        // GET: Retrieve all LOCAL AI nutritional data for authenticated user
        [HttpGet("local")]
        public async Task<IActionResult> GetAllLocalNutritionalInfo()
        {
            // 🔐 Get authenticated user ID from JWT token
            var authenticatedUserId = this.GetAuthenticatedUserId();
            if (string.IsNullOrEmpty(authenticatedUserId))
            {
                return Unauthorized("Invalid or missing authentication token.");
            }

            // Get user profile for the authenticated user
            var userProfile = await _dbContext.UserProfiles
                .FirstOrDefaultAsync(up => up.AppUserId == authenticatedUserId);
            if (userProfile == null)
            {
                return NotFound("User profile not found.");
            }

            var nutritionalInfos = await _dbContext.NutritionalInfos
                .Where(n => n.UserProfileId == userProfile.Id)
                .ToListAsync();

            var localResults = new List<object>();

            foreach (var info in nutritionalInfos)
            {
                try
                {
                    // Try to deserialize as local format
                    var nutritionalInfoWrapper = JsonSerializer.Deserialize<NutritionalInfoWrapper>(info.JsonData);
                    // Only add if it's successfully parsed as local format (not Gemini)
                    if (nutritionalInfoWrapper?.NutritionalInfo != null)
                    {
                        localResults.Add(new 
                        { 
                            id = info.Id, 
                            provider = "local", 
                            data = nutritionalInfoWrapper 
                        });
                    }
                }
                catch
                {
                    // Skip items that can't be parsed as local format
                    continue;
                }
            }

            return Ok(localResults);
        }

        // DELETE: Remove LOCAL AI nutritional data by ID for authenticated user
        [HttpDelete("local/{id}")]
        public async Task<IActionResult> DeleteLocalNutritionalInfo(int id)
        {
            // 🔐 Get authenticated user ID from JWT token
            var authenticatedUserId = this.GetAuthenticatedUserId();
            if (string.IsNullOrEmpty(authenticatedUserId))
            {
                return Unauthorized("Invalid or missing authentication token.");
            }

            // Get user profile for the authenticated user
            var userProfile = await _dbContext.UserProfiles
                .FirstOrDefaultAsync(up => up.AppUserId == authenticatedUserId);
            if (userProfile == null)
            {
                return NotFound("User profile not found.");
            }

            var nutritionalInfo = await _dbContext.NutritionalInfos
                .FirstOrDefaultAsync(n => n.Id == id && n.UserProfileId == userProfile.Id);

            if (nutritionalInfo == null)
            {
                return NotFound(new { message = "Local nutritional information not found." });
            }

            // Verify it's local format before deleting
            try
            {
                var nutritionalInfoWrapper = JsonSerializer.Deserialize<NutritionalInfoWrapper>(nutritionalInfo.JsonData);
                if (nutritionalInfoWrapper?.NutritionalInfo == null)
                {
                    return BadRequest(new { message = "This is not a local AI nutritional record." });
                }
            }
            catch
            {
                return BadRequest(new { message = "This is not a valid local AI nutritional record." });
            }

            _dbContext.NutritionalInfos.Remove(nutritionalInfo);
            await _dbContext.SaveChangesAsync();

            return Ok(new { message = "Local nutritional information successfully deleted." });
        }

        // =====================================================================
        // GEMINI AI FOOD DETECTION FEATURE (Google Gemini API)
        // =====================================================================

        // POST: Upload image, call the Gemini AI API for advanced food detection and nutrition analysis
        [HttpPost("gemini-scan")]
        public async Task<IActionResult> GeminiFoodDetection(IFormFile image)
        {
            // Validate the image file
            if (image == null || image.Length == 0)
            {
                return BadRequest("No image uploaded.");
            }

            if (!image.ContentType.StartsWith("image/"))
            {
                return BadRequest("Uploaded file is not an image.");
            }

            // Validate image size (max 10MB for Gemini)
            if (image.Length > 10 * 1024 * 1024)
            {
                return BadRequest("Image size must be less than 10MB for Gemini AI processing.");
            }

            // 🔐 Get authenticated user ID from JWT token
            var authenticatedUserId = this.GetAuthenticatedUserId();
            if (string.IsNullOrEmpty(authenticatedUserId))
            {
                return Unauthorized("Invalid or missing authentication token.");
            }

            // Get user profile for the authenticated user
            var userProfile = await _dbContext.UserProfiles
                .FirstOrDefaultAsync(up => up.AppUserId == authenticatedUserId);
            if (userProfile == null)
            {
                return NotFound("User profile not found. Please create a profile first.");
            }

            try
            {
                // Call the Gemini AI service to get advanced food detection data
                var rawJson = await _geminiService.DetectFoodAsync(image);

                // Deserialize the Gemini response
                var geminiResponse = JsonSerializer.Deserialize<GeminiFoodDetectionWrapper>(rawJson);

                // Create a new NutritionalInfo object and store the raw JSON string
                var nutritionalInfo = new NutritionalInfo
                {
                    JsonData = rawJson,  // Save the raw JSON data (as a string)
                    UserProfileId = userProfile.Id  // Link to UserProfile
                };

                // Save the data to the database
                _dbContext.NutritionalInfos.Add(nutritionalInfo);
                await _dbContext.SaveChangesAsync();

                // Return the enhanced Gemini response
                return CreatedAtAction(nameof(GetGeminiNutritionalInfo), new { id = nutritionalInfo.Id }, new
                {
                    id = nutritionalInfo.Id,
                    provider = "gemini",
                    response = geminiResponse,
                    processing_note = "New streamlined format"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new 
                { 
                    message = "Internal server error occurred during Gemini food detection",
                    error = ex.Message,
                    timestamp = DateTime.UtcNow,
                    suggestion = "Please try again or use the local food detection endpoint (/scan)"
                });
            }
        }

        // GET: Retrieve GEMINI AI nutritional data by ID for authenticated user
        [HttpGet("gemini/{id}")]
        public async Task<IActionResult> GetGeminiNutritionalInfo(int id)
        {
            // 🔐 Get authenticated user ID from JWT token
            var authenticatedUserId = this.GetAuthenticatedUserId();
            if (string.IsNullOrEmpty(authenticatedUserId))
            {
                return Unauthorized("Invalid or missing authentication token.");
            }

            // Get user profile for the authenticated user
            var userProfile = await _dbContext.UserProfiles
                .FirstOrDefaultAsync(up => up.AppUserId == authenticatedUserId);
            if (userProfile == null)
            {
                return NotFound("User profile not found.");
            }

            var nutritionalInfo = await _dbContext.NutritionalInfos
                .FirstOrDefaultAsync(n => n.Id == id && n.UserProfileId == userProfile.Id);

            if (nutritionalInfo == null)
            {
                return NotFound("Gemini nutritional information not found.");
            }

            try
            {
                // Deserialize as Gemini format
                var geminiResponse = JsonSerializer.Deserialize<GeminiFoodDetectionWrapper>(nutritionalInfo.JsonData);
                if (geminiResponse?.Status == null)
                {
                    return BadRequest("This is not a valid Gemini AI nutritional record.");
                }

                return Ok(new 
                { 
                    id = nutritionalInfo.Id,
                    provider = "gemini", 
                    data = geminiResponse 
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error processing Gemini nutritional data: {ex.Message}");
            }
        }

        // GET: Retrieve all GEMINI AI nutritional data for authenticated user
        [HttpGet("gemini")]
        public async Task<IActionResult> GetAllGeminiNutritionalInfo()
        {
            // 🔐 Get authenticated user ID from JWT token
            var authenticatedUserId = this.GetAuthenticatedUserId();
            if (string.IsNullOrEmpty(authenticatedUserId))
            {
                return Unauthorized("Invalid or missing authentication token.");
            }

            // Get user profile for the authenticated user
            var userProfile = await _dbContext.UserProfiles
                .FirstOrDefaultAsync(up => up.AppUserId == authenticatedUserId);
            if (userProfile == null)
            {
                return NotFound("User profile not found.");
            }

            var nutritionalInfos = await _dbContext.NutritionalInfos
                .Where(n => n.UserProfileId == userProfile.Id)
                .ToListAsync();

            var geminiResults = new List<object>();

            foreach (var info in nutritionalInfos)
            {
                try
                {
                    // Try to deserialize as Gemini format
                    var geminiResponse = JsonSerializer.Deserialize<GeminiFoodDetectionWrapper>(info.JsonData);
                    // Only add if it's successfully parsed as Gemini format (has Status property)
                    if (geminiResponse?.Status != null)
                    {
                        geminiResults.Add(new 
                        { 
                            id = info.Id, 
                            provider = "gemini", 
                            data = geminiResponse 
                        });
                    }
                }
                catch
                {
                    // Skip items that can't be parsed as Gemini format
                    continue;
                }
            }

            return Ok(geminiResults);
        }

        // DELETE: Remove GEMINI AI nutritional data by ID for authenticated user
        [HttpDelete("gemini/{id}")]
        public async Task<IActionResult> DeleteGeminiNutritionalInfo(int id)
        {
            // 🔐 Get authenticated user ID from JWT token
            var authenticatedUserId = this.GetAuthenticatedUserId();
            if (string.IsNullOrEmpty(authenticatedUserId))
            {
                return Unauthorized("Invalid or missing authentication token.");
            }

            // Get user profile for the authenticated user
            var userProfile = await _dbContext.UserProfiles
                .FirstOrDefaultAsync(up => up.AppUserId == authenticatedUserId);
            if (userProfile == null)
            {
                return NotFound("User profile not found.");
            }

            var nutritionalInfo = await _dbContext.NutritionalInfos
                .FirstOrDefaultAsync(n => n.Id == id && n.UserProfileId == userProfile.Id);

            if (nutritionalInfo == null)
            {
                return NotFound(new { message = "Gemini nutritional information not found." });
            }

            // Verify it's Gemini format before deleting
            try
            {
                var geminiResponse = JsonSerializer.Deserialize<GeminiFoodDetectionWrapper>(nutritionalInfo.JsonData);
                if (geminiResponse?.Status == null)
                {
                    return BadRequest(new { message = "This is not a Gemini AI nutritional record." });
                }
            }
            catch
            {
                return BadRequest(new { message = "This is not a valid Gemini AI nutritional record." });
            }

            _dbContext.NutritionalInfos.Remove(nutritionalInfo);
            await _dbContext.SaveChangesAsync();

            return Ok(new { message = "Gemini nutritional information successfully deleted." });
        }
    }
}
