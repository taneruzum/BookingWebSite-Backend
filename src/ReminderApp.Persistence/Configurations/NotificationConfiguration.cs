using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReminderApp.Domain.Constats;
using ReminderApp.Domain.Entities;

namespace ReminderApp.Persistence.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            ConfigureNotificationTable(builder);
        }

        private void ConfigureNotificationTable(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable(TableNames.Notifications);

            builder.HasKey(n => n.Id);

            builder.Property(n => n.Email).HasMaxLength(200).IsRequired();

            builder.Property(u => u.CreatedDate).HasDefaultValue(Time.GetNowGet);

            builder.Property(u => u.isActive).HasDefaultValue(true);

            builder.Property(u => u.Message).HasMaxLength(300).IsRequired();

            builder.Property(u => u.MessageType).IsRequired();
        }
    }
}
