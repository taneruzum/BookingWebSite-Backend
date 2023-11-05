using ReminderApp.Application.Abstractions;
using ReminderApp.Domain.Entities.Base;
using ReminderApp.Persistence.Data;

namespace ReminderApp.Persistence.Repositories.Generic
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ReminderDbContext _context;

        public UnitOfWork(ReminderDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync()
        {
            int result = await _context.SaveChangesAsync();
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
