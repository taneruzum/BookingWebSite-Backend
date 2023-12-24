using MediatR;

namespace ReminderApp.Application.Features.Commands.Meeting.DisactiveMeeting
{
    public record DisactiveMeetingCommand (
        Guid meetingId
    ) : IRequest<bool>;
}
