namespace ReminderApp.Application.Abstractions
{
    public interface IHasDomainEvents
    {
        public IReadOnlyList<IDomainEvent> DomainEvents { get; }

        public void ClearDomainEvents();
    }
}
