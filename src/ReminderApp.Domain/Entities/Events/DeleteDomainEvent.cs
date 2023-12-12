using ReminderApp.Application.Abstractions;

namespace ReminderApp.Domain.Entities.Events
{
    public sealed record DeleteDomainEvent(
         params string[] tableNames
     ) : IDomainEvent;
}
