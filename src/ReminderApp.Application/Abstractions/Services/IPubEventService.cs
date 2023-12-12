namespace ReminderApp.Application.Abstractions.Services
{
    public interface IPubEventService
    {
        Task PublishDomainEventAsync();
    }
}
