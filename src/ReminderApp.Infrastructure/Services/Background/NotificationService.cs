using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReminderApp.Application.Abstractions.Services;
using ReminderApp.Domain.Models;
using Serilog;

namespace ReminderApp.Infrastructure.Services.Background
{
    public class NotificationService : BackgroundService
    {
        private readonly INotificationQueueService _emailQueueService;
        private readonly IServiceProvider _serviceProvider;
        public NotificationService(INotificationQueueService emailQueueService, IServiceProvider serviceProvider)
        {
            _emailQueueService = emailQueueService;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var mailService = _serviceProvider.GetRequiredService<IMailService>();
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_emailQueueService.QueuePersonality.Any())
                {
                    var msg = _emailQueueService.QueuePersonality.Dequeue();
                    await SendEmail(mailService, msg);
                }
                else if (_emailQueueService.QueueAll.Any())
                {
                    var msg = _emailQueueService.QueueAll.Dequeue();
                    await SendEmail(mailService, msg);
                }
                await Task.Delay(1000, stoppingToken);
            }
        }

        public async Task SendEmail(IMailService mailService, NotificationPersonModel msg)
        {
            await mailService.SendMessageAsync(msg.Email, msg.Subject, msg.Message, false, msg.DisplayName);
            Log.Information("Notification Send To {0}", msg.Email);
        }

        public async Task SendEmail(IMailService mailService, NotificationAllModel msg)
        {
            await mailService.SendMessageAsync(msg.Emails, msg.Subject, msg.Message, false, msg.DisplayName);
            Log.Information("Notification Send To All");
        }
    }
}
