using Microsoft.Extensions.Hosting;
using ReminderApp.Application.Abstractions.Services;
using ReminderApp.Domain.Models;
using Serilog;

namespace ReminderApp.Infrastructure.Services.Background
{
    public class NotificationService : BackgroundService
    {
        private readonly INotificationQueueService _emailQueueService;

        public NotificationService(INotificationQueueService emailQueueService)
        {
            _emailQueueService = emailQueueService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_emailQueueService.QueuePersonality.Any())
                {
                    var msg = _emailQueueService.QueuePersonality.Dequeue();
                    await SendEmail(msg);
                }
                else if (_emailQueueService.QueueAll.Any())
                {
                    var msg = _emailQueueService.QueueAll.Dequeue();
                    await SendEmail(msg);
                }
                await Task.Delay(1000, stoppingToken);
            }
        }

        public async Task SendEmail(NotificationPersonModel msg)
        {
            await Task.Delay(1000);
            Log.Information("Notification Send To {0}", msg.Email);
        }

        public async Task SendEmail(NotificationAllModel msg)
        {
            await Task.Delay(1000);
            Log.Information("Notification Send To All");
        }
    }
}
