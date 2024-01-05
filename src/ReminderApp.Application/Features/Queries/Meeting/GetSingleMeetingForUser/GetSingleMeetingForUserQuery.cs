using MediatR;
using ReminderApp.Application.Dtos.Meeting;

namespace ReminderApp.Application.Features.Queries.Meeting.GetSingleMeetingForUser
{
    public record GetSingleMeetingForUserQuery (
        Guid meetingId
    ) : IRequest<GetAllMeetingDto>;
}
