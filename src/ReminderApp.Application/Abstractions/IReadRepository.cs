using System.Linq.Expressions;
using ReminderApp.Domain.Entities.Base;

namespace ReminderApp.Application.Abstractions
{
    public interface IReadRepository<T> where T : BaseModel
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression = null, bool tracking = true, params Expression<Func<T, object>>[] includeEntity);

        Task<T> GetAsync(Expression<Func<T, bool>> expression = null, bool tracking = true, params Expression<Func<T, object>>[] includeEntity);

        Task<T> GetByGuidAsync(Guid id, bool tracking = true);

        Task<bool> AnyAsync(Expression<Func<T, bool>> expression, bool tracking = true);

        Task<int> CountAsync(Expression<Func<T, bool>> expression = null, bool tracking = true);
    }
}
