using MediatR;
using ReminderApp.Application.Abstractions;
using ReminderApp.Application.Abstractions.Services;

namespace ReminderApp.Application.Features.Commands.Comment.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtTokenService _jwtTokenService;
        public CreateCommentCommandHandler(IUnitOfWork unitOfWork, IJwtTokenService jwtTokenService)
        {
            _unitOfWork = unitOfWork;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<bool> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            ReminderApp.Domain.Entities.User? user = await _unitOfWork.GetReadRepository<ReminderApp.Domain.Entities.User>().GetAsync(u => u.Email == request.email);

            ReminderApp.Domain.Entities.Comment comment = new() { Star = request.star, UserComment = request.comment, Id = Guid.NewGuid(), CreatedDate = DateTime.Now, isActive = true, UserId = user.Id };

            if (user is not null)
            {
                bool anyResult = await _unitOfWork.GetReadRepository<ReminderApp.Domain.Entities.Comment>().AnyAsync(c => c.UserId == user.Id);

                if (!anyResult)
                    return await _unitOfWork.GetWriteRepository<ReminderApp.Domain.Entities.Comment>().CreateAsync(comment) ? await _unitOfWork.SaveChangesAsync() > 0 : false;
            }
            return false;
        }
    }
}
