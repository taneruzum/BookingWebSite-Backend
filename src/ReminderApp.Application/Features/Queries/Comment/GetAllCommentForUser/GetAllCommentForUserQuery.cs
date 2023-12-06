using MediatR;
using ReminderApp.Application.Dtos.Comment;

namespace ReminderApp.Application.Features.Queries.Comment.GetAllCommentForUser
{
    public sealed record GetAllCommentForUserQuery(
        ) : IRequest<List<AllCommentDto>>;
}
