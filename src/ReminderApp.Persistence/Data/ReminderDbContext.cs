using Microsoft.EntityFrameworkCore;
using ReminderApp.Application.Abstractions;
using ReminderApp.Domain.Entities;
using ReminderApp.Persistence.Interceptors;

namespace ReminderApp.Persistence.Data
{
    public class ReminderDbContext : DbContext
    {
        private readonly PublishEventInterceptors _publishEventInterceptors;


        public ReminderDbContext()
        {
        }

        public ReminderDbContext(DbContextOptions options, PublishEventInterceptors publishEventInterceptors) : base(options)
        {
            _publishEventInterceptors = publishEventInterceptors;
        }

        public ReminderDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<HubConnection> HubConnections { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ImageUser> ImageUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<List<IDomainEvent>>();
            modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_publishEventInterceptors);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
