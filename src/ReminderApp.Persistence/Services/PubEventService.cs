using MediatR;
using Microsoft.EntityFrameworkCore;
using ReminderApp.Application.Abstractions;
using ReminderApp.Application.Abstractions.Services;
using ReminderApp.Persistence.Data;

namespace ReminderApp.Persistence.Services
{
    public class PubEventService : IPubEventService
    {
        private readonly ReminderDbContext _dbContext;
        private readonly IMediator _mediator;

        public PubEventService(ReminderDbContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;
        }

        public DbContext GetContext() => _dbContext;

        public async Task PublishDomainEventAsync()
        {
            var context = GetContext();
            if (context is null)
                return;

            var entityDomainEvents = context.ChangeTracker.Entries<IHasDomainEvents>()
               .Where(entry => entry.Entity.DomainEvents.Any())
               .Select(entry => entry.Entity).ToList();

            var domainEvents = entityDomainEvents.SelectMany(entry => entry.DomainEvents).ToList();

            entityDomainEvents.ForEach(entity => entity.ClearDomainEvents());

            await PublishToDomainEvents(domainEvents);
        }

        private async Task PublishToDomainEvents(List<IDomainEvent> domainEvents)
        {
            foreach (var domainEvent in domainEvents)
            {
                await _mediator.Publish(domainEvent);
            }
        }
    }
}
