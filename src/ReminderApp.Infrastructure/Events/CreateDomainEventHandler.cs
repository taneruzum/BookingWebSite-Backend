using MediatR;
using ReminderApp.Domain.Constats;
using ReminderApp.Domain.Entities.Events;
using ReminderApp.Infrastructure.Hubs;

namespace ReminderApp.Infrastructure.Events
{
    public sealed class CreateDomainEventHandler : INotificationHandler<CreateDomainEvent>
    {
        private readonly UserHub _userHub;

        public CreateDomainEventHandler(UserHub userHub)
        {
            _userHub = userHub;
        }

        public async Task Handle(CreateDomainEvent notification, CancellationToken cancellationToken)
        {
            foreach (var tableName in notification.tableNames)
            {
                if (tableName == TableNames.Users)
                {
                    await _userHub.SendUserCount();
                }
            }
        }
    }
}
