using MediatR;

namespace ReminderApp.Application.Features.Queries.User.GetUserWithToken
{
    public record GetUserWithTokenCommand(
       string token
   ) : IRequest<Domain.Entities.User>;
}
