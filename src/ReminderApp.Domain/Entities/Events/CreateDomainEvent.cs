using ReminderApp.Application.Abstractions;

namespace ReminderApp.Domain.Entities.Events
{
    public sealed record CreateDomainEvent(
        params string[] tableNames
    ) : IDomainEvent;
}
