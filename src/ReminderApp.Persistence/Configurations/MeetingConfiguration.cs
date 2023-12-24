using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReminderApp.Domain.Constats;
using ReminderApp.Domain.Entities;

namespace ReminderApp.Persistence.Configurations
{
    public class MeetingConfiguration : IEntityTypeConfiguration<Meeting>
    {
        public void Configure(EntityTypeBuilder<Meeting> builder)
        {
            ConfigureHubConnectionTable(builder);
        }

        private void ConfigureHubConnectionTable(EntityTypeBuilder<Meeting> builder)
        {
            builder.ToTable(TableNames.Meetings);

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Day);

            builder.Property(m => m.Hours);

            builder.Property(m => m.Year);

            builder.Property(m => m.Month);

            builder.Property(m => m.Email);

            builder.Property(m => m.MeetingName);
            
            builder.Property(m => m.UserName);

            builder.HasMany(m => m.MeetingItems)
                .WithOne(mi => mi.Meeting)
                .HasForeignKey(mi => mi.MeetingId);

            builder.Property(m => m.CreatedDate).HasDefaultValue(Time.GetNowGet);

            builder.Property(m => m.isActive).HasDefaultValue(true);
        }
    }
}
