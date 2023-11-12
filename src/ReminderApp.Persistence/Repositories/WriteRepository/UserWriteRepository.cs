using ReminderApp.Application.Abstractions.Repositories.Write;
using ReminderApp.Domain.Entities;
using ReminderApp.Persistence.Data;
using ReminderApp.Persistence.Repositories.Generic;

namespace ReminderApp.Persistence.Repositories.WriteRepository
{
    public class UserWriteRepository : WriteRepository<User>, IUserWriteRepository
    {
        private readonly ReminderDbContext _context;

        public UserWriteRepository(ReminderDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
