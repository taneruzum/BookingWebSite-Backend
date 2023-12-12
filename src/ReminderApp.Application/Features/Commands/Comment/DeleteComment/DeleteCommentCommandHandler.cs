using MediatR;
using ReminderApp.Application.Abstractions;

namespace ReminderApp.Application.Features.Commands.Comment.DeleteComment
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCommentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.GetReadRepository<ReminderApp.Domain.Entities.User>().GetAsync(u => u.Id == Guid.Parse(request.UserId), true, u => u.Comment);
            bool dbResul = await _unitOfWork.GetWriteRepository<ReminderApp.Domain.Entities.Comment>().DeleteAsync(user.Comment);
            if (dbResul)
                return await _unitOfWork.SaveChangesAsync() > 0;
            return false;
        }
    }
}
