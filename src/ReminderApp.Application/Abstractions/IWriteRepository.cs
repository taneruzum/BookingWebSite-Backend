using ReminderApp.Domain.Entities.Base;

namespace ReminderApp.Application.Abstractions
{
    public interface IWriteRepository<T> where T : BaseModel
    {
        public Task<bool> CreateAsync(T entity);
        public bool Delete(T entity);
        public Task<bool> DeleteAsync(T entityId);
        public Task<bool> DeleteByIdAsync(Guid id);
        public bool UpdateAsync(T entity);
    }
}
