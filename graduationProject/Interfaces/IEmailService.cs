namespace graduationProject.Interfaces
{
    public interface IEmailService
    {
        Task SendPasswordResetEmailAsync(string email, string resetToken, string userName);
        Task SendWelcomeEmailAsync(string email, string userName);
        Task SendPasswordChangedNotificationAsync(string email, string userName);
    }
} 