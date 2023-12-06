using MediatR;
using ReminderApp.Application.Abstractions;
using ReminderApp.Application.Abstractions.Services;
using ReminderApp.Application.Dtos.Comment;
using ReminderApp.Application.Extensions;

namespace ReminderApp.Application.Features.Queries.Comment.GetAllComment
{
    public class GetAllCommentQueryHandler : IRequestHandler<GetAllCommentQuery, List<AllCommentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private List<AllCommentDto> allComments;
        private readonly IImageService _imageService;
        public GetAllCommentQueryHandler(IUnitOfWork unitOfWork, IImageService imageService)
        {
            _unitOfWork = unitOfWork;
            allComments = new();
            _imageService = imageService;
        }

        public async Task<List<AllCommentDto>> Handle(GetAllCommentQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.Comment>? comments = await _unitOfWork.GetReadRepository<Domain.Entities.Comment>().GetAllAsync();
            foreach (var comment in comments)
            {
                var user = await _unitOfWork.GetReadRepository<Domain.Entities.User>().GetAsync(u => u.Id == comment.UserId);
                var userImage = await _unitOfWork.GetReadRepository<Domain.Entities.ImageUser>().GetAsync(iu => iu.UserId == user.Id);
                var image = await _imageService.GetImageAsync(userImage.ImageId);
                allComments.Add(new() { Star = comment.Star, UserComment = comment.UserComment, UserName = user.Email.EmailShort() });
            }
            return allComments;
        }
    }
}
