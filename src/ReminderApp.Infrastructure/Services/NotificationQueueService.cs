using ReminderApp.Application.Abstractions.Services;
using ReminderApp.Domain.Models;

namespace ReminderApp.Infrastructure.Services
{
    public class NotificationQueueService : INotificationQueueService
    {
        public Queue<NotificationPersonModel> QueuePersonality { get; set; }
        public Queue<NotificationAllModel> QueueAll { get; set; }

        public NotificationQueueService(Queue<NotificationPersonModel> queuePersonality, Queue<NotificationAllModel> queueAll)
        {
            QueuePersonality = queuePersonality;
            QueueAll = queueAll;
        }

    }
}
