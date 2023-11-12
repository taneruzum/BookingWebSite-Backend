using MediatR;
using ReminderApp.Domain.Models;

namespace ReminderApp.Application.Features.Commands.User.RefreshToken
{
    public record RefreshTokenCommand(
        string token
    ) : IRequest<Token>;
}
