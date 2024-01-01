using MediatR;
using ReminderApp.Application.Dtos.Meeting;

namespace ReminderApp.Application.Features.Queries.Meeting.GetMeetingNotification
{
    public record GetPersonalityMeetingNotificationQuery(
        
    ) : IRequest<List<AllPersonalNotificationDto>>;
}
