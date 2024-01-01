using MediatR;
using ReminderApp.Application.Dtos.Meeting;

namespace ReminderApp.Application.Features.Queries.Meeting.GetMeetingNotification
{
    public class GetPersonalityMeetingNotificationQueryHandler : IRequestHandler<GetPersonalityMeetingNotificationQuery, List<AllPersonalNotificationDto>>
    {
        public Task<List<AllPersonalNotificationDto>> Handle(GetPersonalityMeetingNotificationQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
