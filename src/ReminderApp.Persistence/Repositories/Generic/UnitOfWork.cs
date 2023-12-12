using Microsoft.EntityFrameworkCore;
using ReminderApp.Application.Abstractions;
using ReminderApp.Application.Abstractions.Services;
using ReminderApp.Domain.Entities.Base;
using ReminderApp.Persistence.Data;

namespace ReminderApp.Persistence.Repositories.Generic
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ReminderDbContext _context;
        private readonly IPubEventService _pubEventService;

        public UnitOfWork(ReminderDbContext context, IPubEventService pubEventService)
        {
            _context = context;
            _pubEventService = pubEventService;
        }

        public DbSet<T> GetTable<T>(DbContext context) where T : BaseModel
        {
            return context.Set<T>();
        }

        public async Task<int> SaveChangesAsync()
        {
            int result = await _context.SaveChangesAsync();
            await _pubEventService.PublishDomainEventAsync();
            return result;
        }

        public IReadRepository<T> GetReadRepository<T>() where T : BaseModel, new()
        {
            return new ReadRepository<T>(_context);
        }

        public IWriteRepository<T> GetWriteRepository<T>() where T : BaseModel, new()
        {
            return new WriteRepository<T>(_context);
        }
    }
}
