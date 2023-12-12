using MediatR;

namespace ReminderApp.Application.Features.Commands.Comment.CreateComment
{
    public record CreateCommentCommand(
        string email,
        string comment,
        int star
    ) : IRequest<bool>;
}
