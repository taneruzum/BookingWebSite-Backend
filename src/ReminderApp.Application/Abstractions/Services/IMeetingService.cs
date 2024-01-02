namespace ReminderApp.Application.Abstractions.Services
{
    public interface IMeetingService
    {
        public Task<Dictionary<string, int>> GetMeetingVoteCount(Guid meetingId);
    }
}
