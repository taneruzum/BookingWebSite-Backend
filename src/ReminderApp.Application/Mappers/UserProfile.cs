using AutoMapper;
using ReminderApp.Application.Dtos.User;
using ReminderApp.Domain.Entities;

namespace ReminderApp.Application.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>().ReverseMap();

            CreateMap<User, AllUserDto>().ReverseMap();
        }
    }
}
