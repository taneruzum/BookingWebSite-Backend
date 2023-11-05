using MediatR;
using ReminderApp.Application.Dtos.User;

namespace ReminderApp.Application.Features.Commands.User.CreateUser
{
    public record CreateUserCommand
     (
         CreateUserDto createUserDto
     ) : IRequest<bool>;
}
