using ReminderApp.Application.Abstractions;

namespace ReminderApp.Domain.Entities.Base
{
    public class BaseModel : IHasDomainEvents
    {
        public Guid Id { get; set; }
        public bool isActive { get; set; }
        public DateTime CreatedDate { get; set; }

        protected List<IDomainEvent> _domainEvents = new();
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

        public BaseModel()
        {
            Id = Guid.NewGuid();
            isActive = true;
            CreatedDate = DateTime.Now;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

        public int DomainEventCount() => DomainEvents.Count();
    }
}
