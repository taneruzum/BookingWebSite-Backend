using AutoMapper;
using MediatR;
using ReminderApp.Application.Abstractions;
using ReminderApp.Application.Abstractions.Services;
using ReminderApp.Application.Extensions;
using ReminderApp.Domain.Constats;
using ReminderApp.Domain.Entities;
using ReminderApp.Domain.Entities.Events;
using System.Globalization;

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
                    if (!IsMeetingStartValid(meetingDetailDto.MeetingsStart))
                        return false;
                    dbResults.Add(await _unitOfWork.GetWriteRepository<MeetingDetail>().CreateAsync(new() { MeetingFinish = GetMeetingFinishValue(request.CreateMeetingDto.Hours, request.CreateMeetingDto.Minute, meetingDetailDto.MeetingsStart), MeetingsDay = meetingDetailDto.MeetingsDay, MeetingStart = meetingDetailDto.MeetingsStart, MeetingId = meeting.Id ,VoteCount = 0}));
                }
            }

            if (dbResult is true && dbResults.All(res => res == true))
            {
                //---------------------// GONNA TEST THIS PLACE \\--------------------------------\\
                //meeting.AddDomainEvent(new SendEmailEvent(GetUrlFormat(Message.meetingCreateMessage, meeting.Id.ToString()), Message.meetingCreateSubject, Message.meetingCreateDisplayName, request.CreateMeetingDto.Emails.ToArray()));
                return await _unitOfWork.SaveChangesAsync() > 0;
            }
            return false;
        }

        private string GetUrlFormat(string str, string id)
        {
            return $"{str}/{ClientPageUrls.Dashboard}/{id}";
        }

        private string GetMeetingFinishValue(int hour, int minute, string meetingstart)
        {
            TimeSpan meetingStartTime = TimeSpan.Parse(meetingstart);

            TimeSpan combinedTime = meetingStartTime.Add(new TimeSpan(hour, minute, 0));

            return $"{combinedTime.Hours:D2}:{combinedTime.Minutes:D2}";
        }

        private string GetStrDatetimeFormat(string meetingsStart,string format)
        {
            if (DateTime.TryParseExact(meetingsStart, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDateTime))
            {
                string formattedTime = parsedDateTime.ToString("HH:mm");
                return formattedTime;
            }
            return string.Empty;
        }

        private bool IsMeetingStartValid(string meetingsStart)
        {
            if (meetingsStart.Contains(":"))
                return true;
            else
                return false;
        }
    }
}
