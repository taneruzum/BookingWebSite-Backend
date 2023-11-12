using ReminderApp.Application.Abstractions.Repositories.Write;
using ReminderApp.Domain.Entities;
using ReminderApp.Persistence.Data;
using ReminderApp.Persistence.Repositories.Generic;

namespace ReminderApp.Persistence.Repositories.WriteRepository
{
    public class ImageUserWriteRepository : WriteRepository<ImageUser>, IImageUserWriteRepository
    {
        public ImageUserWriteRepository(ReminderDbContext context) : base(context)
        {
        }
    }
}
