using Microsoft.EntityFrameworkCore;
using ReminderApp.Domain.Entities;
using System.Reflection.Metadata;

namespace ReminderApp.Persistence.Data
{
    public class ReminderDbContext : DbContext
    {
        protected ReminderDbContext()
        {
        }
        public ReminderDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<HubConnection> HubConnections { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
