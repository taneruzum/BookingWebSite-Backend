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
        private GetAllMeetingDto getAllMeetingDtos;

        public GetSingleMeetingForUserQueryHandler(IUnitOfWork unitOfWork, IMeetingService meetingService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _meetingService = meetingService;
            getAllMeetingDtos = new GetAllMeetingDto();
            _mapper = mapper;
        }

        public async Task<GetAllMeetingDto> Handle(GetSingleMeetingForUserQuery request, CancellationToken cancellationToken)
        {
            //await _unitOfWork.GetReadRepository<ReminderApp.Domain.Entities.Meeting>().GetAsync()

            var meeting = await _unitOfWork.GetReadRepository<ReminderApp.Domain.Entities.Meeting>().GetAsync(m => m.Id == request.meetingId && m.isActive == true, true, m => m.MeetingItems, m => m.MeetingDetails);

            GetAllMeetingDto getAllMeetingDto = _mapper.Map<GetAllMeetingDto>(meeting);

            foreach (var meetingItem in meeting.MeetingItems)
                getAllMeetingDto.GetAllMeetingItemDto.Add(_mapper.Map<GetAllMeetingItemDto>(meetingItem));

            foreach (var meetingDetail in meeting.MeetingDetails)
            {
                GetAllMeetingDetailDto newMeetingDetailDto = _mapper.Map<GetAllMeetingDetailDto>(meetingDetail);

                var dicDayAndCount = await _meetingService.GetMeetingVoteCount(meeting.Id);

                if (!getAllMeetingDto.GetAllMeetingDetailDtos.Any(x => x.MeetingsDay == newMeetingDetailDto.MeetingsDay))
                {
                    newMeetingDetailDto.VoteCount = meetingDetail.VoteCount;
                    newMeetingDetailDto.MeetingFinish = meetingDetail.MeetingFinish;
                    newMeetingDetailDto.MeetingDetailId = meetingDetail.Id;
                    getAllMeetingDto.GetAllMeetingDetailDtos.Add(newMeetingDetailDto);
                }
            }

            return getAllMeetingDtos;

        }
    }
}
