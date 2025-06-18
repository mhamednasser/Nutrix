using graduationProject.Configurations;
using graduationProject.Interfaces;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace graduationProject.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IOptions<EmailSettings> emailSettings, ILogger<EmailService> logger)
        {
            _emailSettings = emailSettings.Value;
            _logger = logger;
        }

        public async Task SendPasswordResetEmailAsync(string email, string resetToken, string userName)
        {
            try
            {
                var resetLink = $"{_emailSettings.FrontendUrl}/reset-password?token={Uri.EscapeDataString(resetToken)}&email={Uri.EscapeDataString(email)}";
                
                var subject = "Reset Your Nutrix Password";
                var body = GeneratePasswordResetEmailBody(userName, resetLink);

                await SendEmailAsync(email, subject, body);
                
                _logger.LogInformation("Password reset email sent successfully to {Email}", email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send password reset email to {Email}", email);
                throw;
            }
        }

        public async Task SendWelcomeEmailAsync(string email, string userName)
        {
            try
            {
                var subject = "Welcome to Nutrix - Your Fitness Journey Starts Here!";
                var body = GenerateWelcomeEmailBody(userName);

                await SendEmailAsync(email, subject, body);
                
                _logger.LogInformation("Welcome email sent successfully to {Email}", email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send welcome email to {Email}", email);
                throw;
            }
        }

        public async Task SendPasswordChangedNotificationAsync(string email, string userName)
        {
            try
            {
                var subject = "Nutrix Password Changed Successfully";
                var body = GeneratePasswordChangedEmailBody(userName);

                await SendEmailAsync(email, subject, body);
                
                _logger.LogInformation("Password changed notification sent successfully to {Email}", email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send password changed notification to {Email}", email);
                throw;
            }
        }

        private async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            using var client = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.SmtpPort);
            client.EnableSsl = _emailSettings.EnableSsl;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(_emailSettings.SenderEmail, _emailSettings.SenderPassword);

            using var message = new MailMessage();
            message.From = new MailAddress(_emailSettings.SenderEmail, _emailSettings.SenderName);
            message.To.Add(toEmail);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;
            message.BodyEncoding = Encoding.UTF8;

            await client.SendMailAsync(message);
        }

        private string GeneratePasswordResetEmailBody(string userName, string resetLink)
        {
            return $@"<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <style>
        body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #333; }}
        .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
        .header {{ background: linear-gradient(135deg, #667eea 0%, #764ba2 100%); color: white; padding: 30px; text-align: center; border-radius: 10px 10px 0 0; }}
        .content {{ background: #f9f9f9; padding: 30px; border-radius: 0 0 10px 10px; }}
        .button {{ display: inline-block; background: #667eea; color: white; padding: 15px 30px; text-decoration: none; border-radius: 5px; font-weight: bold; margin: 20px 0; }}
        .footer {{ text-align: center; margin-top: 30px; color: #666; font-size: 12px; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>🏋️ Nutrix</h1>
            <h2>Password Reset Request</h2>
        </div>
        <div class='content'>
            <h3>Hi {userName},</h3>
            <p>We received a request to reset your password for your Nutrix account.</p>
            <p>Click the button below to reset your password:</p>
            <p style='text-align: center;'>
                <a href='{resetLink}' class='button'>Reset My Password</a>
            </p>
            <p><strong>This link will expire in 24 hours.</strong></p>
            <p>If you didn't request this password reset, please ignore this email.</p>
        </div>
        <div class='footer'>
            <p>© 2024 Nutrix - Your Fitness & Nutrition Companion</p>
        </div>
    </div>
</body>
</html>";
        }

        private string GenerateWelcomeEmailBody(string userName)
        {
            return $@"<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <style>
        body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #333; }}
        .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
        .header {{ background: linear-gradient(135deg, #667eea 0%, #764ba2 100%); color: white; padding: 30px; text-align: center; border-radius: 10px 10px 0 0; }}
        .content {{ background: #f9f9f9; padding: 30px; border-radius: 0 0 10px 10px; }}
        .button {{ display: inline-block; background: #667eea; color: white; padding: 15px 30px; text-decoration: none; border-radius: 5px; font-weight: bold; margin: 20px 0; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>🏋️ Welcome to Nutrix!</h1>
        </div>
        <div class='content'>
            <h3>Hi {userName},</h3>
            <p>Welcome to Nutrix! We're excited to help you achieve your fitness and nutrition goals.</p>
            <p>Get started by completing your profile to receive personalized recommendations!</p>
            <p style='text-align: center;'>
                <a href='{_emailSettings.FrontendUrl}/profile' class='button'>Complete Your Profile</a>
            </p>
        </div>
    </div>
</body>
</html>";
        }

        private string GeneratePasswordChangedEmailBody(string userName)
        {
            return $@"<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <style>
        body {{ font-family: Arial, sans-serif; line-height: 1.6; color: #333; }}
        .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
        .header {{ background: linear-gradient(135deg, #667eea 0%, #764ba2 100%); color: white; padding: 30px; text-align: center; border-radius: 10px 10px 0 0; }}
        .content {{ background: #f9f9f9; padding: 30px; border-radius: 0 0 10px 10px; }}
        .alert {{ background: #d4edda; color: #155724; padding: 15px; border-radius: 5px; margin: 20px 0; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>🔒 Nutrix Security Alert</h1>
        </div>
        <div class='content'>
            <h3>Hi {userName},</h3>
            <div class='alert'>
                <strong>✅ Your password has been successfully changed!</strong>
            </div>
            <p>This email confirms that your password was updated on {DateTime.UtcNow:MMM dd, yyyy}.</p>
            <p>If you didn't make this change, please contact our support team immediately.</p>
        </div>
    </div>
</body>
</html>";
        }
    }
} 