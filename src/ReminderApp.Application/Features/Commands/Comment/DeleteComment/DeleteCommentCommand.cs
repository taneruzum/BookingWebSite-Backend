using MediatR;

namespace ReminderApp.Application.Features.Commands.Comment.DeleteComment
{
    public record DeleteCommentCommand(
        string email
    ) : IRequest<bool>;
}
