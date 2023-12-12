using MediatR;

namespace ReminderApp.Application.Features.Queries.User.GetUserWithToken
{
    public record GetUserWithTokenQuery(
       string token
   ) : IRequest<Domain.Entities.User>;
}
