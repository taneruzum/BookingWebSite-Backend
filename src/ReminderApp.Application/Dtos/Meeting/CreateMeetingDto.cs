namespace ReminderApp.Application.Dtos.Meeting
{
    public class CreateMeetingDto
    {
        public string? Year { get; set; } = DateTime.Now.Year.ToString();
        public string? Month { get; set; } = DateTime.Now.Month.ToString();
        public string Day { get; set; }
        public string Hours { get; set; }
        public string MeetingName { get; set; }
        
        public List<string> Emails { get; set; }
    }
}
