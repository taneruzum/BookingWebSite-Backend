using ReminderApp.Domain.Entities.Base;

namespace ReminderApp.Application.Abstractions
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();

        IReadRepository<T> GetReadRepository<T>() where T : BaseModel, new();
        IWriteRepository<T> GetWriteRepository<T>() where T : BaseModel, new();
    }
}
