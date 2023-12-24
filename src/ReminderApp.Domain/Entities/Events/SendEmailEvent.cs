using ReminderApp.Application.Abstractions;

namespace ReminderApp.Domain.Entities.Events
{
    public sealed record SendEmailEvent(
        params string[] emails
    ) : IDomainEvent;
}
