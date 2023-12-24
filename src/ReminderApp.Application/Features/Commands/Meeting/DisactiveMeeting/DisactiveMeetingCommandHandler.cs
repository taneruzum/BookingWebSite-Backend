using MediatR;
using ReminderApp.Application.Abstractions;

namespace ReminderApp.Application.Features.Commands.Meeting.DisactiveMeeting
{
    public class DisactiveMeetingCommandHandler : IRequestHandler<DisactiveMeetingCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DisactiveMeetingCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DisactiveMeetingCommand request, CancellationToken cancellationToken)
        {
            var meetingAndItems = await _unitOfWork.GetReadRepository<ReminderApp.Domain.Entities.Meeting>().GetAsync(m => m.Id == request.meetingId && m.isActive == true, true, m => m.MeetingItems);
            if (meetingAndItems is not null && meetingAndItems.MeetingItems.Count() > 0)
            {
                meetingAndItems.isActive = false;

                foreach (var meetingItem in meetingAndItems.MeetingItems)
                    meetingItem.isActive = false;

                return await _unitOfWork.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}
