using Microsoft.EntityFrameworkCore;
using ReminderApp.Application.Abstractions;
using ReminderApp.Domain.Entities.Base;
using ReminderApp.Persistence.Data;

namespace ReminderApp.Persistence.Repositories.Generic
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseModel
    {
        private readonly ReminderDbContext _context;

        public WriteRepository(ReminderDbContext context)
        {
            _context = context;
        }

        private DbSet<T> _table => _context.Set<T>();

        public async Task<bool> CreateAsync(T entity)
        {
            try
            {
                await _table.AddAsync(entity);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                _table.Remove(entity);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(T entityId)
        {
            try
            {
                _table.Remove(entityId);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteByIdAsync(Guid Id)
        {
            try
            {
                var data = await _table.Where(t => t.Id == Id).FirstOrDefaultAsync();
                _table.Remove(data);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool UpdateAsync(T entity)
        {
            try
            {
                _table.Update(entity);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}
