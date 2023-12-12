using ReminderApp.Application.Abstractions.Repositories.Read;
using ReminderApp.Domain.Entities;
using ReminderApp.Persistence.Data;
using ReminderApp.Persistence.Repositories.Generic;

namespace ReminderApp.Persistence.Repositories.ReadRepository
{
    public class UserReadRepository : ReadRepository<User>, IUserReadRepository
    {
        public UserReadRepository(ReminderDbContext context) : base(context)
        {
        }
    }
}
