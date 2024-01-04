using MediatR;
using ReminderApp.Application.Dtos.Meeting;

namespace ReminderApp.Application.Features.Commands.Meeting.AddVoteForMeeting
{
    public record AddVoteForMeetingCommand (
        VoteForMeetingDto VoteForMeetingDto
    ) : IRequest<bool>;
}
