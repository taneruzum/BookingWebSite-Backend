using ReminderApp.Domain.Models;

namespace ReminderApp.Application.Abstractions.Services
{
    public interface INotificationQueueService
    {
        Queue<NotificationPersonModel> QueuePersonality { get; set; }
        Queue<NotificationAllModel> QueueAll { get; set; }
    }
}
