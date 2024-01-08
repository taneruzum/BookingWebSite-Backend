using AutoMapper;
using MediatR;
using ReminderApp.Application.Abstractions;
using ReminderApp.Application.Abstractions.Services;
using ReminderApp.Application.Dtos.Meeting;

namespace ReminderApp.Application.Features.Queries.Meeting.GetSingleMeetingForUser
{
    public class GetSingleMeetingForUserQueryHandler : IRequestHandler<GetSingleMeetingForUserQuery, GetAllMeetingDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMeetingService _meetingService;
        private readonly IMapper _mapper;
        private readonly IJwtTokenService _jwtTokenService;
        private GetAllMeetingDto getAllMeetingDto;

        public GetSingleMeetingForUserQueryHandler(IUnitOfWork unitOfWork, IMeetingService meetingService, IMapper mapper, IJwtTokenService jwtTokenService)
        {
            _unitOfWork = unitOfWork;
            _meetingService = meetingService;
            getAllMeetingDto = new GetAllMeetingDto();
            _mapper = mapper;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<GetAllMeetingDto> Handle(GetSingleMeetingForUserQuery request, CancellationToken cancellationToken)
        {
            var meeting = await _unitOfWork.GetReadRepository<ReminderApp.Domain.Entities.Meeting>().GetAsync(m => m.Id == request.meetingId && m.isActive == true, true, m => m.MeetingItems, m => m.MeetingDetails);

            GetAllMeetingDto getAllMeetingDto = _mapper.Map<GetAllMeetingDto>(meeting);

            var userInfo = await _unitOfWork.GetReadRepository<ReminderApp.Domain.Entities.User>().GetAsync(u => u.Email == meeting.Email);
            getAllMeetingDto.UserId = userInfo.Id;

            foreach (var meetingItem in meeting.MeetingItems)
            {
                var mapData = _mapper.Map<GetAllMeetingItemDto>(meetingItem);

                var userItemInfo = await _unitOfWork.GetReadRepository<ReminderApp.Domain.Entities.User>().GetAsync(u => u.Email == meetingItem.Email);

                mapData.UserId = userItemInfo.Id;
                mapData.IsVoted = meetingItem.Voted;
                getAllMeetingDto.GetAllMeetingItemDto.Add(mapData);
            }

            foreach (var meetingDetail in meeting.MeetingDetails)
            {
                GetAllMeetingDetailDto newMeetingDetailDto = _mapper.Map<GetAllMeetingDetailDto>(meetingDetail);

                //var dicDayAndCount = await _meetingService.GetMeetingVoteCount(meeting.Id);

                if (!getAllMeetingDto.GetAllMeetingDetailDtos.Any(x => x.MeetingDetailId == newMeetingDetailDto.MeetingDetailId))
                {
                    newMeetingDetailDto.VoteCount = meetingDetail.VoteCount;
                    newMeetingDetailDto.MeetingFinish = meetingDetail.MeetingFinish;
                    newMeetingDetailDto.MeetingDetailId = meetingDetail.Id;
                    getAllMeetingDto.GetAllMeetingDetailDtos.Add(newMeetingDetailDto);
                }
            }
            return getAllMeetingDto;
        }
    }
}
