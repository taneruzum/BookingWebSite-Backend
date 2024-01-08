namespace ReminderApp.Application.Dtos.Meeting
{
    public class GetAllMeetingDto
    {
        public Guid Id { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public int Hours { get; set; }
        public int Minute { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Guid? UserId { get; set; } = Guid.Empty;
        public string MeetingName { get; set; }
        public DateTime CreatedDate { get; set; }

        public List<GetAllMeetingItemDto> GetAllMeetingItemDto { get; set; } = new();

        public List<GetAllMeetingDetailDto> GetAllMeetingDetailDtos { get; set; } = new();
    }
}
