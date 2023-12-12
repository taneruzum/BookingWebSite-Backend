using MediatR;
using ReminderApp.Domain.Constats;
using ReminderApp.Domain.Entities.Events;

namespace ReminderApp.Infrastructure.Events
{
    public sealed class UpdateDomainEventHandler : INotificationHandler<UpdateDomainEvent>
    {
        //private readonly UserHub _userHub;

        //public UpdateDomainEventHandler(UserHub userHub)
        //{
        //    _userHub = userHub;
        //}

        public async Task Handle(UpdateDomainEvent notification, CancellationToken cancellationToken)
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
