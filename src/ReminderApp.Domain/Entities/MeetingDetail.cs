using ReminderApp.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReminderApp.Domain.Entities
{
    [Table("MeetingItems")]
    public class MeetingDetail : BaseModel
    {
        public string MeetingsDay { get; set; }
        public string MeetingStart { get; set; } 
        public string MeetingFinish { get; set; }
        public int VoteCount { get; set; } = 0;

        public Guid MeetingId { get; set; }
        public Meeting Meeting { get; set; }
    }
}
