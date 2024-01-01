using Microsoft.Extensions.Configuration;
using ReminderApp.Application.Abstractions.Services;
using System.Net;
using System.Net.Mail;

namespace ReminderApp.Infrastructure.Services
{
    public class MailService : IMailService
    {
        readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMessageAsync(string to, string subject, string body, bool isBodyHtml, string displayName = "")
        {
            await SendMessageAsync(new[] { to }, subject, body, isBodyHtml, displayName);
        }

        public async Task SendMessageAsync(string[] tos, string subject, string body, bool isBodyHtml = true, string displayName = "")
        {
            MailMessage mail = new();
            mail.IsBodyHtml = isBodyHtml;
            foreach (var to in tos)
                mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.From = new(_configuration["EmailConfiguration:Username"], displayName ?? "", System.Text.Encoding.UTF8);

            SmtpClient smtp = new();
            smtp.Credentials = new NetworkCredential(_configuration["EmailConfiguration:Username"], _configuration["EmailConfiguration:Password"]);
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Host = "smtp.gmail.com";
            await smtp.SendMailAsync(mail);
        }

        public async Task SendMessageWithImageAsync(string[] tos, string subject, string body, bool isBodyHtml, string imagePath, string displayName = "")
        {
            MailMessage mail = new();
            mail.IsBodyHtml = isBodyHtml;
            foreach (var to in tos)
                mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.From = new(_configuration["EmailConfiguration:Username"], displayName ?? "", System.Text.Encoding.UTF8);
            mail.Attachments.Add(new Attachment(imagePath));

            SmtpClient smtp = new();
            smtp.Credentials = new NetworkCredential(_configuration["EmailConfiguration:Username"], _configuration["EmailConfiguration:Password"]);
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Host = "smtp.gmail.com";
            await smtp.SendMailAsync(mail);
        }
    }
}
