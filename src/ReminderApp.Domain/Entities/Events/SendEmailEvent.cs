using ReminderApp.Application.Abstractions;

namespace ReminderApp.Domain.Entities.Events
{
    public sealed record SendEmailEvent(
        string message,
        string subhect,
        string displayName,
        params string[] emails
    ) : IDomainEvent;
}
