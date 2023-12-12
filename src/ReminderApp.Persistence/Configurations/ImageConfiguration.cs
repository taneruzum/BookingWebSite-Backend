using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReminderApp.Domain.Constats;
using ReminderApp.Domain.Entities;

namespace ReminderApp.Persistence.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            ConfigureImageTable(builder);
        }

        private void ConfigureImageTable(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable(TableNames.Images);

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name);

            builder.Property(i => i.Path);

            builder.Property(i => i.Photo);

            builder.Property(i => i.isActive).HasDefaultValue(true);

            builder.Property(i => i.CreatedDate).HasDefaultValue(Time.GetNowGet);

            builder.HasMany(i => i.ImageUsers)
              .WithOne(iu => iu.Image)
              .HasForeignKey(iu => iu.ImageId);
        }
    }
}
