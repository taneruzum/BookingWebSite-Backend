using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReminderApp.Domain.Constats;
using ReminderApp.Domain.Entities;
using System.Reflection.Emit;

namespace ReminderApp.Persistence.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable(TableNames.Comments);

            builder.HasKey(c => c.Id);

            builder.Property(c => c.isActive).HasDefaultValue(true);

            builder.Property(c => c.CreatedDate).HasDefaultValue(Time.GetNowGet);

            builder.Property(c => c.Star);

            builder.Property(c => c.UserComment);

            builder.HasOne(c => c.User)
                   .WithOne(u => u.Comment)
                   .HasForeignKey<Comment>(c => c.UserId);
        }
    }
}
