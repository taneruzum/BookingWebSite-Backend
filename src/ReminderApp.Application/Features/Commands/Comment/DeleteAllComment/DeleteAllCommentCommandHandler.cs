using MediatR;
using ReminderApp.Application.Abstractions;
using ReminderApp.Domain.Entities;

namespace ReminderApp.Application.Features.Commands.Comment.DeleteAllComment
{
    public class DeleteAllCommentCommandHandler : IRequestHandler<DeleteAllCommentCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAllCommentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteAllCommentCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.GetWriteRepository<ReminderApp.Domain.Entities.Comment>().AllDelete();
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
    }
}
