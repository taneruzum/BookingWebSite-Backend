using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using ReminderApp.Application.Abstractions;
using ReminderApp.Application.Abstractions.Services;
using System.Text;

namespace ReminderApp.Application.Features.Commands.Comment.AddComment
{
    public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICookieService _cookieService;
        public AddCommentCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, ICookieService cookieService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _cookieService = cookieService;
        }

        public async Task<bool> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            ReminderApp.Domain.Entities.Comment comment = new() { Star = request.AddCommentDto.Star, UserComment = request.AddCommentDto.UserComment, Id = Guid.NewGuid(), CreatedDate = DateTime.Now, isActive = true };

            string? email = _cookieService.GetCookieValue("Email");

            if (email is not null)
            {
                ReminderApp.Domain.Entities.User? user = await _unitOfWork.GetReadRepository<ReminderApp.Domain.Entities.User>().GetAsync(u => u.Email == email);

                if (user is not null)
                {
                    ReminderApp.Domain.Entities.Comment? existComment = await _unitOfWork.GetReadRepository<ReminderApp.Domain.Entities.Comment>().GetAsync(c => c.UserId == user.Id);

                    if (existComment is null)
                    {
                        comment.UserId = user.Id;
                        return await _unitOfWork.GetWriteRepository<ReminderApp.Domain.Entities.Comment>().CreateAsync(comment) ? await _unitOfWork.SaveChangesAsync() > 0 : false;
                    }

                    existComment.UserId = user.Id;
                    existComment.UserComment = request.AddCommentDto.UserComment;
                    return _unitOfWork.GetWriteRepository<ReminderApp.Domain.Entities.Comment>().UpdateAsync(existComment) ? await _unitOfWork.SaveChangesAsync() > 0 : false;
                }
            }
            return false;
        }
    }
}
