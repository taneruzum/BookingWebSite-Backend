using Microsoft.EntityFrameworkCore;
using ReminderApp.Application.Abstractions;
using ReminderApp.Domain.Entities;

namespace ReminderApp.Persistence.Data
{
    public class ReminderDbContext : DbContext
    {
        public ReminderDbContext()
        {
        }

        public ReminderDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<HubConnection> HubConnections { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ImageUser> ImageUsers { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<MeetingItem> MeetingItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<List<IDomainEvent>>();
            modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
