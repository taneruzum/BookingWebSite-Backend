using MediatR;
using ReminderApp.Application.Abstractions.Services;
using ReminderApp.Domain.Entities.Events;

namespace ReminderApp.Infrastructure.Events
{
    public class SendEmailEventHandler : INotificationHandler<SendEmailEvent>
    {
        private readonly INotificationQueueService _notificationQueueService;

        public SendEmailEventHandler(INotificationQueueService notificationQueueService)
        {
            _notificationQueueService = notificationQueueService;
        }

        public async Task Handle(SendEmailEvent notification, CancellationToken cancellationToken)
        {
            _notificationQueueService.QueueAll.Enqueue(new() { Message = notification.message, DisplayName = notification.displayName, Subject = notification.subhect, Emails = notification.emails });
        }
    }
}
