using MediatR;
using ReminderApp.Application.Dtos.User;

namespace ReminderApp.Application.Features.Queries.User.GetAllUser
{
    public record GetAllUserQuery(

    ) : IRequest<List<AllUserDto>>;
}
