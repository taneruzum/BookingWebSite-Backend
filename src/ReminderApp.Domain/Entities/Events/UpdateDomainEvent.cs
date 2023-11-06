using ReminderApp.Application.Abstractions;

namespace ReminderApp.Domain.Entities.Events
{
    public sealed record UpdateDomainEvent(
        params string[] tableNames
     ) : IDomainEvent;
}
