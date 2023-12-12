using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReminderApp.Domain.Constats;
using ReminderApp.Domain.Entities;

namespace ReminderApp.Persistence.Configurations
{
    public class HubConnectionConfiguration : IEntityTypeConfiguration<HubConnection>
    {
        public void Configure(EntityTypeBuilder<HubConnection> builder)
        {
            ConfigureHubConnectionTable(builder);
        }

        private void ConfigureHubConnectionTable(EntityTypeBuilder<HubConnection> builder)
        {
            builder.ToTable(TableNames.HubConnections);

            builder.HasKey(h => h.Id);

            builder.Property(h => h.ConnectionId);

            builder.Property(h => h.CreatedDate).HasDefaultValue(Time.GetNowGet);

            builder.Property(h => h.isActive).HasDefaultValue(true);

            builder.Property(h => h.Email).HasMaxLength(200);
        }
    }
}
