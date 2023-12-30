using ReminderApp.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReminderApp.Domain.Entities
{
    [Table("Meetings")]
    public class Meeting : BaseModel
    {
        [NotMapped]
        private DateTime _now;

        public string Year { get; }
        public string Month { get; }
        public string Email { get; set; }
        public string MeetingName { get; set; }
        public string UserName { get; set; }
        public int Hours { get; set; }

        public List<MeetingItem> MeetingItems { get; set; }
        public List<MeetingDetail> MeetingDetails { get; set; }


        public Meeting()
        {
            _now = DateTime.Now;
            Year = _now.Year.ToString();
            Month = _now.Month.ToString();
        }
    }
}
