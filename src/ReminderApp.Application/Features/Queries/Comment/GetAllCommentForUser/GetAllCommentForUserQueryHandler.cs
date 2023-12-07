using MediatR;
using Microsoft.AspNetCore.Http;
using ReminderApp.Application.Abstractions;
using ReminderApp.Application.Abstractions.Services;
using ReminderApp.Application.Dtos.Comment;
using ReminderApp.Application.Extensions;

namespace ReminderApp.Application.Features.Queries.Comment.GetAllCommentForUser
{
    public class GetAllCommentForUserQueryHandler : IRequestHandler<GetAllCommentForUserQuery, List<AllCommentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private List<AllCommentDto> allComments;
        private readonly IImageService _imageService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        List<AllCommentDto> allCommentDtos;
        public GetAllCommentForUserQueryHandler(IUnitOfWork unitOfWork, IImageService imageService, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            allComments = new();
            _imageService = imageService;
            allCommentDtos = new();
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<AllCommentDto>> Handle(GetAllCommentForUserQuery request, CancellationToken cancellationToken)
        {
            string? email = _httpContextAccessor.HttpContext.Session.GetString(ReminderApp.Domain.Constats.TableProperty.Email);

            ReminderApp.Domain.Entities.User? user = await _unitOfWork.GetReadRepository<ReminderApp.Domain.Entities.User>().GetAsync(u => u.Email == email);

            List<Domain.Entities.Comment> comments = await _unitOfWork.GetReadRepository<Domain.Entities.Comment>().GetAllAsync(c => c.UserId == user.Id);

            foreach (var comment in comments)
                allCommentDtos.Add(new() { Star = comment.Star, UserComment = comment.UserComment, UserName = user.Email.EmailShort() });

            return allCommentDtos;
        }
    }
}
