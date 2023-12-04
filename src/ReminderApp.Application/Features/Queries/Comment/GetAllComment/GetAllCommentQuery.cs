using MediatR;
using ReminderApp.Application.Dtos.Comment;

namespace ReminderApp.Application.Features.Queries.Comment.GetAllComment
{
    public sealed record GetAllCommentQuery(
        ) : IRequest<List<AllCommentDto>>;
}
