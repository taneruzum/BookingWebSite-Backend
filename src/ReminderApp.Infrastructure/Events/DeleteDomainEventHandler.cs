using MediatR;
using ReminderApp.Domain.Constats;
using ReminderApp.Domain.Entities.Events;

namespace ReminderApp.Infrastructure.Events
{
    public sealed class DeleteDomainEventHandler : INotificationHandler<DeleteDomainEvent>
    {
        //private readonly UserHub _userHub;

        //public DeleteDomainEventHandler(UserHub userHub)
        //{
        //    _userHub = userHub;
        //}

        public async Task Handle(DeleteDomainEvent notification, CancellationToken cancellationToken)
        {
            foreach (var tableName in notification.tableNames)
            {
                if (tableName == TableNames.Users)
                {
                    //await _userHub.SendUserCount();
                }
            }
        }
    }
}
