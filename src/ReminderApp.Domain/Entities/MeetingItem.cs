using ReminderApp.Domain.Entities.Base;
using ReminderApp.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReminderApp.Domain.Entities
{
    [Table("MeetingItems")]
    public class MeetingItem : BaseModel
    {
        public string PersonEmail { get; set; }
        public PersonSeeType PersonSeeType { get; set; } = PersonSeeType.Unknown;

        public Guid MeetingId { get; set; }
        public Meeting Meeting { get; set; }
    }
}
