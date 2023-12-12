using MediatR;

namespace ReminderApp.Application.Features.Commands.User.DeleteUser
{
    public record DeleteUserCommand(
          Guid id
      ) : IRequest<bool>;
}
