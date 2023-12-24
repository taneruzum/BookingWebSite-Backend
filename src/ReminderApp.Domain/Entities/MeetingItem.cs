using ReminderApp.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReminderApp.Domain.Entities
{
    [Table("MeetingItems")]
    public class MeetingItem : BaseModel
    {
        public string Email { get; set; }

        public Guid MeetingId { get; set; }
        public Meeting Meeting { get; set; }
    }
}
