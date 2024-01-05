using MediatR;
using ReminderApp.Application.Abstractions;
using ReminderApp.Domain.Entities;

namespace ReminderApp.Application.Features.Commands.Meeting.AddVoteForMeeting
{
    public class AddVoteForMeetingCommandHandler : IRequestHandler<AddVoteForMeetingCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddVoteForMeetingCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(AddVoteForMeetingCommand request, CancellationToken cancellationToken)
        {
            var meetingAndDetails = await _unitOfWork.GetReadRepository<ReminderApp.Domain.Entities.Meeting>().GetAsync(m => m.Id == request.VoteForMeetingDto.MeetingId, true, m => m.MeetingItems);

            foreach (var meetingItem in meetingAndDetails.MeetingItems)
                if(meetingItem.Email == request.VoteForMeetingDto.Email && meetingItem.Voted == true)
                    return false;

            foreach (var MeetingDetailId in request.VoteForMeetingDto.MeetingDetailIds)
            {
                var meetingDetail = await _unitOfWork.GetReadRepository<MeetingDetail>().GetAsync(md => md.Id == MeetingDetailId);
                meetingDetail.VoteCount += 1;
            }

            foreach (var meetingItem in meetingAndDetails.MeetingItems)
                if (meetingItem.Email == request.VoteForMeetingDto.Email && meetingItem.Voted == false)
                {
                    meetingItem.Voted = true;
                    break;
                }

            return await _unitOfWork.SaveChangesAsync() > 0;
        }
    }
}
