using ReminderApp.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReminderApp.Domain.Entities
{
    [Table("Meetings")]
    public class Meeting : BaseModel
    {
        [NotMapped]
        private DateTime NowDate;

        public int Year { get; }
        public int Month { get; }
        public int Day { get; set; }
        public string Hours { get; set; }
        public string Subject { get; set; }
        public string Email { get; set; }

        public List<MeetingItem> MeetingItems { get; set; }

        public Meeting()
        {
            NowDate = DateTime.Now;
            Year = NowDate.Year;
            Month = NowDate.Month;
        }
    }
}
