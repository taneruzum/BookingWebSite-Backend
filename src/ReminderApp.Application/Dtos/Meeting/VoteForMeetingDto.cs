namespace ReminderApp.Application.Dtos.Meeting
{
    public class VoteForMeetingDto
    {
        public Guid MeetingId { get; set; }

        public List<Guid> MeetingDetailIds { get; set; }
    }
}
