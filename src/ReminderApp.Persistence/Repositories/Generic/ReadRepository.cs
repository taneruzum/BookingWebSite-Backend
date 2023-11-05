using Microsoft.EntityFrameworkCore;
using ReminderApp.Application.Abstractions;
using ReminderApp.Domain.Entities.Base;
using ReminderApp.Persistence.Data;
using System.Linq.Expressions;

namespace ReminderApp.Persistence.Repositories.Generic
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseModel
    {
        private readonly ReminderDbContext _context;

        public ReadRepository(ReminderDbContext context)
        {
            _context = context;
        }

        private DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression, bool tracking = true)
        {
            try
            {
                var query = Table.AsQueryable();
                if (!tracking)
                    query = query.AsNoTracking();

                if (expression is not null)
                    return await query.AnyAsync(expression);

                if (expression != null)
                    query = query.Where(expression);

                return await query.AnyAsync();
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> expression = null, bool tracking = true)
        {
            try
            {
                var query = Table.AsQueryable();
                if (!tracking)
                    query = query.AsNoTracking();

                if (expression is not null)
                    return await query.CountAsync(expression);

                if (expression != null)
                    query = query.Where(expression);

                return await query.CountAsync();
            }
            catch (System.Exception)
            {
                return default;
            }
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression = null, bool tracking = true, params Expression<Func<T, object>>[] includeEntity)
        {
            try
            {
                var query = Table.AsQueryable();
                if (!tracking)
                    query = query.AsNoTracking();

                if (includeEntity.Any())
                    foreach (var include in includeEntity)
                        query = query.Include(include);

                if (expression != null)
                    query = query.Where(expression);

                return await query.ToListAsync();
            }
            catch (System.Exception)
            {
                return default;
            }
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression = null, bool tracking = true, params Expression<Func<T, object>>[] includeEntity)
        {
            try
            {
                var query = Table.AsQueryable();
                if (!tracking)
                    query = query.AsNoTracking();

                if (includeEntity.Any())
                    foreach (var include in includeEntity)
                        query = query.Include(include);

                if (expression != null)
                    query = query.Where(expression);

                return await query.SingleOrDefaultAsync();
            }
            catch (System.Exception)
            {
                return default;
            }
        }

        public async Task<T> GetByGuidAsync(Guid id, bool tracking = true)
        {
            try
            {
                var query = Table.AsQueryable();
                if (!tracking)
                    query = query.AsNoTracking();

                return await Table.FindAsync(id);
            }
            catch (System.Exception)
            {
                return default;
            }
        }
    }
}
