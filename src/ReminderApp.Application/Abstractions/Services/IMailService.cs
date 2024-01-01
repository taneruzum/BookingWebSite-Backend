namespace ReminderApp.Application.Abstractions.Services
{
    public interface IMailService
    {
        Task SendMessageAsync(string to, string subject, string body, bool isBodyHtml = true, string displayName = "");
        Task SendMessageAsync(string[] tos, string subject, string body, bool isBodyHtml = true, string displayName = "");
        Task SendMessageWithImageAsync(string[] tos, string subject, string body, bool isBodyHtml, string imagePath, string displayName = "");
    }
}
