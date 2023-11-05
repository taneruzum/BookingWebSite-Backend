using ReminderApp.Application.Abstractions.Repositories.Write;
using ReminderApp.Domain.Entities;
using ReminderApp.Persistence.Data;
using ReminderApp.Persistence.Repositories.Generic;

namespace ReminderApp.Persistence.Repositories.WriteRepository
{
    public class HubConnectionWriteRepository : WriteRepository<HubConnection>, IHubConnectionWriteRepository
    {
        public HubConnectionWriteRepository(ReminderDbContext context) : base(context)
        {
        }
    }
}
