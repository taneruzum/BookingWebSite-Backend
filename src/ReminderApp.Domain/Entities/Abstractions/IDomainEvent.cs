using MediatR;

namespace ReminderApp.Application.Abstractions
{
    public interface IDomainEvent : INotification
    {
    }
}
