using ReminderApp.Domain.Entities.Base;
using ReminderApp.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReminderApp.Domain.Entities
{
    [Table("Notifications")]
    public class Notification : BaseModel
    {
        public string Email { get; set; }
        public string Message { get; set; }
        public MessageType MessageType { get; set; }
    }
}
