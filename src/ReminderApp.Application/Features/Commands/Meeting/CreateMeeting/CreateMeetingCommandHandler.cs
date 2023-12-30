using AutoMapper;
using MediatR;
using ReminderApp.Application.Abstractions;
using ReminderApp.Application.Abstractions.Services;
using ReminderApp.Application.Extensions;
using ReminderApp.Domain.Entities;

namespace ReminderApp.Application.Features.Commands.Meeting.CreateMeeting
{
    public class CreateMeetingCommandHandler : IRequestHandler<CreateMeetingCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private bool dbResult;
        private List<bool> dbResults;
        private readonly IJwtTokenService _jwtTokenService;

        public CreateMeetingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IJwtTokenService jwtTokenService)
        {
            dbResult = false;
            dbResults = new List<bool>();
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<bool> Handle(CreateMeetingCommand request, CancellationToken cancellationToken)
        {
            var user = await _jwtTokenService.GetUserWithTokenAsync(request.token);

            var meeting = _mapper.Map<ReminderApp.Domain.Entities.Meeting>(request.CreateMeetingDto);
            meeting.Id = Guid.NewGuid();
            meeting.Email = user.Email;
            meeting.UserName = user.Email.EmailShort();

            dbResult = await _unitOfWork.GetWriteRepository<ReminderApp.Domain.Entities.Meeting>().CreateAsync(meeting);

            foreach (var email in request.CreateMeetingDto.Emails)
                dbResults.Add(await _unitOfWork.GetWriteRepository<ReminderApp.Domain.Entities.MeetingItem>().CreateAsync(new() { MeetingId = meeting.Id, Email = email, Id = Guid.NewGuid(), CreatedDate = DateTime.Now }));

            if (dbResult is true && dbResults.All(res => res == true))
            {
                foreach (var meetingDetailDto in request.CreateMeetingDto.MeetingDetailDtos)
                {
                    dbResults.Add(await _unitOfWork.GetWriteRepository<MeetingDetail>().CreateAsync(new() { MeetingFinish = meetingDetailDto.MeetingsFinish, MeetingsDay = meetingDetailDto.MeetingsDay, MeetingStart = meetingDetailDto.MeetingsStart, MeetingId = meeting.Id }));
                }
            }

            if (dbResult is true && dbResults.All(res => res == true))
                //meeting.AddDomainEvent(new SendEmailEvent(request.CreateMeetingDto.Emails.ToArray())); // GONNA TEST THIS PLACE !!!
                return await _unitOfWork.SaveChangesAsync() > 0;
            return false;
        }
    }
}
