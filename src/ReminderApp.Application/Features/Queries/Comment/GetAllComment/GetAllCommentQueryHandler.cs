using MediatR;
using ReminderApp.Application.Abstractions;
using ReminderApp.Application.Dtos.Comment;
using ReminderApp.Application.Extensions;

namespace ReminderApp.Application.Features.Queries.Comment.GetAllComment
{
    public class GetAllCommentQueryHandler : IRequestHandler<GetAllCommentQuery, List<AllCommentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private List<AllCommentDto> allCommentDtos;

        public GetAllCommentQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            allCommentDtos = new();
        }

        public async Task<List<AllCommentDto>> Handle(GetAllCommentQuery request, CancellationToken cancellationToken)
        {
            var comments = await _unitOfWork.GetReadRepository<Domain.Entities.Comment>().GetAllAsync(null, true, c => c.User);
            foreach (var comment in comments)
            {
                var test = comment.User.Email.EmailShort();
                allCommentDtos.Add(new() { Star = comment.Star, UserComment = comment.UserComment, UserName = comment.User.Email.EmailShort() ?? string.Empty });
            }
            return allCommentDtos;
        }
    }
}
