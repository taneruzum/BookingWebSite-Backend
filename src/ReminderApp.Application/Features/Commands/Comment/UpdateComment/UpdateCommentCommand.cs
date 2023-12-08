using MediatR;

namespace ReminderApp.Application.Features.Commands.Comment.UpdateComment
{
    public record UpdateCommentCommand(
        string email,
        string comment,
        int star
    ) : IRequest<bool>;
}
