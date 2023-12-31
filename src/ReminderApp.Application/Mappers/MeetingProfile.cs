using AutoMapper;
using ReminderApp.Application.Dtos.Meeting;

namespace ReminderApp.Application.Mappers
{
    public class MeetingProfile : Profile
    {
        public MeetingProfile()
        {
            CreateMap<ReminderApp.Domain.Entities.Meeting, CreateMeetingDto>().ReverseMap();
            CreateMap<ReminderApp.Domain.Entities.MeetingItem, CreateMeetingDto>().ReverseMap();
            CreateMap<ReminderApp.Domain.Entities.MeetingItem,GetAllMeetingItemDto>().ReverseMap();
            CreateMap<ReminderApp.Domain.Entities.Meeting, GetAllMeetingDto>().ReverseMap();
            CreateMap<ReminderApp.Domain.Entities.Meeting, GetAllMeetingDto>().ReverseMap();
            CreateMap<ReminderApp.Domain.Entities.MeetingDetail, GetAllMeetingDetailDto>().ReverseMap();
        }
    }
}
