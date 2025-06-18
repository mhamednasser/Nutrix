using graduationProject.DTOs;
using graduationProject.Interfaces;
using graduationProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.Extensions.Logging;

namespace graduationProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IJwtService _jwtService;
        private readonly IEmailService _emailService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(
            UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager, 
            IJwtService jwtService,
            IEmailService emailService,
            ILogger<AuthController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
            _emailService = emailService;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingUser = await _userManager.FindByEmailAsync(registerDto.Email);
                if (existingUser != null)
                {
                    return BadRequest(new { Message = "User with this email already exists." });
                }

                var user = new AppUser
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email
                };

                var result = await _userManager.CreateAsync(user, registerDto.Password);
                if (result.Succeeded)
                {
                    var token = await _jwtService.GenerateTokenAsync(user);
                    var refreshToken = await _jwtService.GenerateRefreshTokenAsync();

                    var response = new AuthResponseDto
                    {
                        Token = token,
                        RefreshToken = refreshToken,
                        ExpiresAt = DateTime.UtcNow.AddMinutes(120) // Match JWT expiry
                    };

                    return Ok(response);
                }
                else
                {
                    return BadRequest(new { Message = "Registration failed.", Errors = result.Errors.Select(e => e.Description) });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred during registration.", Error = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var user = await _userManager.FindByNameAsync(loginDto.Username);
                if (user == null)
                {
                    return Unauthorized(new { Message = "Invalid username or password." });
                }

                var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
                if (result.Succeeded)
                {
                    var token = await _jwtService.GenerateTokenAsync(user);
                    var refreshToken = await _jwtService.GenerateRefreshTokenAsync();

                    var response = new AuthResponseDto
                    {
                        Token = token,
                        RefreshToken = refreshToken,
                        ExpiresAt = DateTime.UtcNow.AddMinutes(120) // Match JWT expiry
                    };

                    return Ok(response);
                }
                else if (result.IsLockedOut)
                {
                    return StatusCode(423, new { Message = "Account is locked out." });
                }
                else
                {
                    return Unauthorized(new { Message = "Invalid username or password." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred during login.", Error = ex.Message });
            }
        }

        [HttpGet("google-login")]
        public IActionResult GoogleLogin()
        {
            var redirectUrl = Url.Action("GoogleResponse", "Auth");
            var properties = _signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
            return Challenge(properties, "Google");
        }

        [HttpGet("google-response")]
        public async Task<IActionResult> GoogleResponse()
        {
            try
            {
                var info = await _signInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return BadRequest(new { Message = "Error loading external login information." });
                }

                var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
                if (user == null)
                {
                    var email = info.Principal.FindFirst(ClaimTypes.Email)?.Value;
                    if (string.IsNullOrEmpty(email))
                    {
                        return BadRequest(new { Message = "Email not provided by Google." });
                    }

                    user = new AppUser
                    {
                        UserName = email,
                        Email = email
                    };

                    var createResult = await _userManager.CreateAsync(user);
                    if (!createResult.Succeeded)
                    {
                        return BadRequest(new { Message = "Failed to create user.", Errors = createResult.Errors.Select(e => e.Description) });
                    }

                    var addLoginResult = await _userManager.AddLoginAsync(user, info);
                    if (!addLoginResult.Succeeded)
                    {
                        return BadRequest(new { Message = "Failed to add external login.", Errors = addLoginResult.Errors.Select(e => e.Description) });
                    }
                }

                var token = await _jwtService.GenerateTokenAsync(user);
                var refreshToken = await _jwtService.GenerateRefreshTokenAsync();

                var response = new AuthResponseDto
                {
                    Token = token,
                    RefreshToken = refreshToken,
                    ExpiresAt = DateTime.UtcNow.AddMinutes(120)
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred during Google authentication.", Error = ex.Message });
            }
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto refreshTokenDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Validate the current token (even if expired)
                var principal = _jwtService.ValidateToken(refreshTokenDto.Token);
                if (principal == null)
                {
                    return Unauthorized(new { Message = "Invalid token." });
                }

                var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized(new { Message = "Invalid token claims." });
                }

                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return Unauthorized(new { Message = "User not found." });
                }

                // In a real application, you should validate the refresh token
                // For now, we'll generate new tokens
                var newToken = await _jwtService.GenerateTokenAsync(user);
                var newRefreshToken = await _jwtService.GenerateRefreshTokenAsync();

                var response = new AuthResponseDto
                {
                    Token = newToken,
                    RefreshToken = newRefreshToken,
                    ExpiresAt = DateTime.UtcNow.AddMinutes(120)
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred during token refresh.", Error = ex.Message });
            }
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto forgotPasswordDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var user = await _userManager.FindByEmailAsync(forgotPasswordDto.Email);
                if (user == null)
                {
                    // Don't reveal that the user doesn't exist for security
                    return Ok(new { Message = "If your email is registered, you will receive a password reset link." });
                }

                // Generate password reset token
                var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

                // TODO: In production, only send email and return generic message
                // For development/testing, we'll return the token
                try
                {
                    await _emailService.SendPasswordResetEmailAsync(user.Email!, resetToken, user.UserName ?? "User");
                    return Ok(new { Message = "Password reset link has been sent to your email." });
                }
                catch (Exception emailEx)
                {
                    _logger.LogWarning(emailEx, "Failed to send email, returning token for development testing");
                    
                    // Development fallback - return token for testing
                    return Ok(new { 
                        Message = "Password reset token generated. (Email service not configured - Development Mode)",
                        ResetToken = resetToken,
                        Email = user.Email,
                        Note = "In production, this token would be sent via email only."
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while processing forgot password request for {Email}", forgotPasswordDto.Email);
                return StatusCode(500, new { Message = "An error occurred while processing your request. Please try again later." });
            }
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var user = await _userManager.FindByEmailAsync(resetPasswordDto.Email);
                if (user == null)
                {
                    return BadRequest(new { Message = "Invalid reset request." });
                }

                // Reset the password using the token
                var result = await _userManager.ResetPasswordAsync(user, resetPasswordDto.Token, resetPasswordDto.NewPassword);
                if (result.Succeeded)
                {
                    // Send confirmation email that password was changed
                    await _emailService.SendPasswordChangedNotificationAsync(user.Email!, user.UserName ?? "User");
                    
                    return Ok(new { Message = "Password has been reset successfully." });
                }
                else
                {
                    return BadRequest(new { 
                        Message = "Failed to reset password.", 
                        Errors = result.Errors.Select(e => e.Description) 
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while resetting password for {Email}", resetPasswordDto.Email);
                return StatusCode(500, new { Message = "An error occurred while resetting your password. Please try again later." });
            }
        }
    }
}
