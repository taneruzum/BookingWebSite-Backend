using MediatR;
using ReminderApp.Application.Dtos.Meeting;

namespace ReminderApp.Application.Features.Queries.Meeting.GetAllMeetings
{
    public record GetAllMeetingsQuery (
        
    ) : IRequest<List<GetAllMeetingDto>>;
}
