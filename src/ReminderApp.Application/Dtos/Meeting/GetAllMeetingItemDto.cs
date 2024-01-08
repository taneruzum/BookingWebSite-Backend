namespace ReminderApp.Application.Dtos.Meeting
{
    public class GetAllMeetingItemDto
    {
        public Guid Id { get; set; }
        public Guid MeetingId { get; set; }
        public string Email { get; set; }
        public Guid? UserId { get; set; } = Guid.Empty;

        public DateTime CreatedDate { get; set; }
    }
}
