using ReminderApp.Domain.Entities;

namespace ReminderApp.Application.Abstractions.Repositories.Write
{
    public interface IUserWriteRepository : IWriteRepository<User>
    {
        Task<int> SaveChangesAsync();
    }
}
