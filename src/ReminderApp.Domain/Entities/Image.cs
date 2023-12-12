using ReminderApp.Domain.Entities.Base;
using ReminderApp.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReminderApp.Domain.Entities
{
    [Table("Images")]
    public class Image : BaseModel
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public byte[] Photo { get; set; }

        public FileType FileType { get; set; } = FileType.image;
        public ContentType ContentType { get; set; } = ContentType.jpeg;

        public List<ImageUser>? ImageUsers { get; set; }
    }
}
