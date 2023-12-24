using MediatR;
using ReminderApp.Application.Dtos.Meeting;

namespace ReminderApp.Application.Features.Commands.Meeting.CreateMeeting
{
    public record CreateMeetingCommand (
        CreateMeetingDto CreateMeetingDto,
        string token
    ) : IRequest<bool>;
}
