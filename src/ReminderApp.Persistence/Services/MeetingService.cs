using ReminderApp.Application.Abstractions;
using ReminderApp.Application.Abstractions.Services;
using ReminderApp.Domain.Entities;

namespace ReminderApp.Persistence.Services
{
    public class MeetingService : IMeetingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MeetingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Dictionary<string,int>> GetMeetingVoteCount(Guid meetingId)
        {
            var meetings = await _unitOfWork.GetReadRepository<Meeting>().GetAllAsync(m => m.Id == meetingId, true, m => m.MeetingItems);

            var countByDay = meetings.SelectMany(m => m.MeetingDetails)
                    .GroupBy(meeting => meeting.MeetingsDay)
                    .ToDictionary(group => group.Key, group => group.Count());

            return countByDay;
        }
    }
}
