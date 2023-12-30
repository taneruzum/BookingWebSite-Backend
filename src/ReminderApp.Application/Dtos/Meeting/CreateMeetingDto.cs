namespace ReminderApp.Application.Dtos.Meeting
{
    public class CreateMeetingDto
    {
        public string Year { get; } = DateTime.Now.Year.ToString();
        public string Month { get; } = DateTime.Now.Month.ToString();
        public string MeetingName { get; set; }
        public int Hours { get; set; }

        public List<MeetingDetailDto> MeetingDetailDtos { get; set; }
        public List<string> Emails { get; set; }
    }
}
