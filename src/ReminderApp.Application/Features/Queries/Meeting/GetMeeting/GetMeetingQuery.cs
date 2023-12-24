using MediatR;
using ReminderApp.Application.Dtos.Meeting;

namespace ReminderApp.Application.Features.Queries.Meeting.GetMeeting
{
    public record GetMeetingQuery (
        string token
    ) : IRequest<List<GetAllMeetingDto>>;
}
