using MediatR;
using ReminderApp.Application.Dtos.User;

namespace ReminderApp.Application.Features.Commands.User.LoginUser
{
    public record LoginUserCommand(
           LoginUserDto loginUserDto
       ) : IRequest<(bool isSuccess, string token)>;
}
