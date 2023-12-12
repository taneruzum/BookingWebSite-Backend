using MediatR;
using ReminderApp.Application.Abstractions;

namespace ReminderApp.Application.Features.Commands.Comment.UpdateComment
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCommentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            ReminderApp.Domain.Entities.User? user = await _unitOfWork.GetReadRepository<ReminderApp.Domain.Entities.User>().GetAsync(u => u.Email == request.email, true, u => u.Comment);

            if (user.Comment is null)
                return false;

            ReminderApp.Domain.Entities.Comment comment = new() { Star = request.star, UserComment = request.comment, Id = Guid.NewGuid(), CreatedDate = DateTime.Now, isActive = true, UserId = user.Id };

            if (user is not null)
            {
                Guid? existComment = user.Comment.UserId;

                if (existComment is not null)
                {
                    user.Comment.UserComment = request.comment;
                    user.Comment.Star = request.star;
                    user.Comment.CreatedDate = DateTime.Now;

                    return _unitOfWork.GetWriteRepository<ReminderApp.Domain.Entities.User>().UpdateAsync(user) ? await _unitOfWork.SaveChangesAsync() > 0 : false;
                }
            }
            return false;
        }
    }
}
