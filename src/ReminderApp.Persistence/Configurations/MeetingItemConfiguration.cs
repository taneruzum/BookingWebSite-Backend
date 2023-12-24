using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReminderApp.Domain.Constats;
using ReminderApp.Domain.Entities;
using ReminderApp.Domain.Enums;

namespace ReminderApp.Persistence.Configurations
{
    public class MeetingItemConfiguration : IEntityTypeConfiguration<MeetingItem>
    {
        public void Configure(EntityTypeBuilder<MeetingItem> builder)
        {
            ConfigureMeetingItemTable(builder);
        }

        private void ConfigureMeetingItemTable(EntityTypeBuilder<MeetingItem> builder)
        {
            builder.ToTable(TableNames.MeetingItem);

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Email);

            builder.HasOne(mi => mi.Meeting)
               .WithMany(m => m.MeetingItems)
               .HasForeignKey(mi => mi.MeetingId);

            builder.Property(m => m.CreatedDate).HasDefaultValue(Time.GetNowGet);

            builder.Property(m => m.isActive).HasDefaultValue(true);
        }
    }
}
