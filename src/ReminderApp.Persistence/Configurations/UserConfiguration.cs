using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReminderApp.Domain.Constats;
using ReminderApp.Domain.Entities;
using System.Reflection.Emit;

namespace ReminderApp.Persistence.Configurations
{
    public sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            ConfigureUserTable(builder);
        }

        private void ConfigureUserTable(EntityTypeBuilder<User> builder)
        {
            //builder.ToTable(TableNames.Users);

            //builder.HasKey(u => u.Id);

            //builder.Property(u => u.Email).HasMaxLength(200).IsRequired()
            //    .HasAnnotation("RegularExpression", "[email_regex]");

            //builder.Property(u => u.isActive).HasDefaultValue(true);

            //builder.Property(u => u.CreatedDate).HasDefaultValue(Time.GetNowGet);

            //builder.Property(u => u.Password).HasMaxLength(200).IsRequired();

            //builder.HasMany(u => u.ImageUsers)
            //  .WithOne(iu => iu.User)
            //  .HasForeignKey(iu => iu.UserId);

            //--------------------------------------------------

            builder.ToTable(TableNames.Users);

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email).HasMaxLength(200).IsRequired()
                .HasAnnotation("RegularExpression", "[email_regex]");

            builder.Property(u => u.isActive).HasDefaultValue(true);

            builder.Property(u => u.CreatedDate).HasDefaultValue(Time.GetNowGet);

            builder.Property(u => u.Password).HasMaxLength(200).IsRequired();

            builder.HasMany(u => u.ImageUsers)
              .WithOne(iu => iu.User)
              .HasForeignKey(iu => iu.UserId);

            builder.HasOne(u => u.Comment)
                .WithOne(c => c.User)
                .HasForeignKey<Comment>(c => c.UserId);
        }
    }
}
