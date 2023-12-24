namespace ReminderApp.Application.Dtos.Meeting
{
    public class CreateMeetingDto
    {
        public string Year { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }
        public string Hours { get; set; }
        public string MeetingName { get; set; }
        
        public List<string> Emails { get; set; }
    }
}
