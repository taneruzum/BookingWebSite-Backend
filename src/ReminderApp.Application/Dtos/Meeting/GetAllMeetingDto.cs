namespace ReminderApp.Application.Dtos.Meeting
{
    public class GetAllMeetingDto
    {
        public Guid Id { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }
        public string Hours { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string MeetingName { get; set; }

        public List<GetAllMeetingItemDto> GetAllMeetingItemDto { get; set; } = new();
    }
}
