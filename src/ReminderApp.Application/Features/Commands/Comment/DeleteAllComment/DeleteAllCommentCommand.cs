using MediatR;

namespace ReminderApp.Application.Features.Commands.Comment.DeleteAllComment
{
    public record DeleteAllCommentCommand(
        
    ) : IRequest<bool>;
}
