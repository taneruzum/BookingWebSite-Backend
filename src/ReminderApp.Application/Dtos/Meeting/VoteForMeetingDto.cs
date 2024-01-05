using System.ComponentModel.DataAnnotations;

namespace ReminderApp.Application.Dtos.Meeting
{
    public class VoteForMeetingDto
    {
        public Guid MeetingId { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public List<Guid> MeetingDetailIds { get; set; }
    }
}
