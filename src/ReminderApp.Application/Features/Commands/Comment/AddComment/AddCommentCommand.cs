using MediatR;
using ReminderApp.Application.Dtos.Comment;

namespace ReminderApp.Application.Features.Commands.Comment.AddComment
{
    public record AddCommentCommand(
       AddCommentDto AddCommentDto
    ) : IRequest<bool>;
}
