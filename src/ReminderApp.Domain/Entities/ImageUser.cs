using ReminderApp.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReminderApp.Domain.Entities
{
    [Table("ImageUsers")]
    public class ImageUser : BaseModel
    {
        public Guid UserId { get; set; }
        public User User { get; set; }


        public Guid ImageId { get; set; }
        public Image Image { get; set; }
    }
}
