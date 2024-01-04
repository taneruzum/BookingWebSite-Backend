using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReminderApp.Domain.Constats;
using ReminderApp.Domain.Entities;

namespace ReminderApp.Persistence.Configurations
{
    public class MeetingDetailConfiguration : IEntityTypeConfiguration<MeetingDetail>
    {
        public void Configure(EntityTypeBuilder<MeetingDetail> builder)
        {
            ConfigureMeetingDetailTable(builder);
        }

        private void ConfigureMeetingDetailTable(EntityTypeBuilder<MeetingDetail> builder)
        {
            builder.ToTable(TableNames.MeetingDetail);

            builder.HasKey(m => m.Id);

            builder.Property(m => m.MeetingFinish);

            builder.Property(m => m.MeetingStart);

            builder.Property(m => m.MeetingsDay);

            builder.Property(m => m.VoteCount);

            builder.HasOne(md => md.Meeting)
                     .WithMany(m => m.MeetingDetails)
                     .HasForeignKey(md => md.MeetingId)
                     .OnDelete(DeleteBehavior.Cascade);

            builder.Property(m => m.CreatedDate).HasDefaultValue(Time.GetNowGet);

            builder.Property(m => m.isActive).HasDefaultValue(true);
        }
    }
}
