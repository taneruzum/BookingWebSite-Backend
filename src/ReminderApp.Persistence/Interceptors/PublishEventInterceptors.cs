using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ReminderApp.Application.Abstractions;

namespace ReminderApp.Persistence.Interceptors
{
    public class PublishEventInterceptors : SaveChangesInterceptor
    {
        private readonly IMediator _mediator;

        public PublishEventInterceptors(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            //PublishDomainEvents(eventData.Context).GetAwaiter().GetResult();
            return base.SavingChanges(eventData, result);
        }

        public async override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            //await PublishDomainEvents(eventData.Context);
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private async Task PublishDomainEvents(DbContext? dbContext)
        {
            if (dbContext is null)
                return;

            var entityDomainEvents = dbContext.ChangeTracker.Entries<IHasDomainEvents>()
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
