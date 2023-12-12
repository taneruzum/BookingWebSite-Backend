using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ReminderApp.Persistence.Data;

namespace ReminderApp.Persistence
{
    public class DesignTimeContext : IDesignTimeDbContextFactory<ReminderDbContext>
    {
        public ReminderDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ReminderDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ReminderDbContext;Trusted_Connection=True;");
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
