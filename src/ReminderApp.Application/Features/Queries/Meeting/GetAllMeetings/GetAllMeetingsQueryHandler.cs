using AutoMapper;
using MediatR;
using ReminderApp.Application.Abstractions;
using ReminderApp.Application.Dtos.Meeting;
using ReminderApp.Domain.Entities;

namespace ReminderApp.Application.Features.Queries.Meeting.GetAllMeetings
{
    public class GetAllMeetingsQueryHandler : IRequestHandler<GetAllMeetingsQuery, List<GetAllMeetingDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private List<string> Emails;
        private List<GetAllMeetingDto> getAllMeetingDtos;
        private readonly IMapper _mapper;
        public GetAllMeetingsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            Emails = new List<string>();
            getAllMeetingDtos = new List<GetAllMeetingDto>();
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetAllMeetingDto>> Handle(GetAllMeetingsQuery request, CancellationToken cancellationToken)
        {
            var meetings = await _unitOfWork.GetReadRepository<ReminderApp.Domain.Entities.Meeting>().GetAllAsync(null,true,m => m.MeetingItems);

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
