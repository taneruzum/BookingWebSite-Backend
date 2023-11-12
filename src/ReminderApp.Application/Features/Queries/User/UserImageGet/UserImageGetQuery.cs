using MediatR;
using ReminderApp.Domain.Entities;

namespace ReminderApp.Application.Features.Queries.User.UserImageGet
{
    public sealed record UserImageGetQuery(
        string token
    ) : IRequest<Image>;
}