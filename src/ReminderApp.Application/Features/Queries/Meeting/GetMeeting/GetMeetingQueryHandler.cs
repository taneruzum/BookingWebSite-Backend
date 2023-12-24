using AutoMapper;
using MediatR;
using ReminderApp.Application.Abstractions;
using ReminderApp.Application.Abstractions.Services;
using ReminderApp.Application.Dtos.Meeting;

namespace ReminderApp.Application.Features.Queries.Meeting.GetMeeting
{
    public class GetMeetingQueryHandler : IRequestHandler<GetMeetingQuery, List<GetAllMeetingDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtTokenService _jwtTokenService;
        private List<GetAllMeetingDto> getAllMeetingDtos;
        private readonly IMapper _mapper;
        public GetMeetingQueryHandler(IUnitOfWork unitOfWork, IJwtTokenService jwtTokenService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _jwtTokenService = jwtTokenService;
            getAllMeetingDtos = new List<GetAllMeetingDto>();
            _mapper = mapper;
        }

        public async Task<List<GetAllMeetingDto>> Handle(GetMeetingQuery request, CancellationToken cancellationToken)
        {
            var user = await _jwtTokenService.GetUserWithTokenAsync(request.token);

            var meetings = await _unitOfWork.GetReadRepository<ReminderApp.Domain.Entities.Meeting>().GetAllAsync(m => m.Email == user.Email && m.isActive == true, true, m => m.MeetingItems);

            foreach (var meeting in meetings)
            {
                GetAllMeetingDto getAllMeetingDto = _mapper.Map<GetAllMeetingDto>(meeting);

                foreach (var meetingItem in meeting.MeetingItems)
                    getAllMeetingDto.GetAllMeetingItemDto.Add(_mapper.Map<GetAllMeetingItemDto>(meetingItem));

                getAllMeetingDtos.Add(getAllMeetingDto);
            }

            return getAllMeetingDtos;
        }
    }
}