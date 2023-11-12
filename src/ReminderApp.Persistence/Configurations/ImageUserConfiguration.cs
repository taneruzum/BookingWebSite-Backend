using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReminderApp.Domain.Constats;
using ReminderApp.Domain.Entities;

namespace ReminderApp.Persistence.Configurations
{
    public class ImageUserConfiguration : IEntityTypeConfiguration<ImageUser>
    {
        public void Configure(EntityTypeBuilder<ImageUser> builder)
        {
            ConfigureImageUserTable(builder);
        }

        private void ConfigureImageUserTable(EntityTypeBuilder<ImageUser> builder)
        {
            builder.ToTable(TableNames.ImageUsers);

            builder.HasKey(iu => iu.Id);

            builder.HasOne(iu => iu.User)
              .WithMany(u => u.ImageUsers)
              .HasForeignKey(iu => iu.UserId);

            builder.HasOne(iu => iu.Image)
                .WithMany(i => i.ImageUsers)
                .HasForeignKey(iu => iu.ImageId);
        }
    }
}
