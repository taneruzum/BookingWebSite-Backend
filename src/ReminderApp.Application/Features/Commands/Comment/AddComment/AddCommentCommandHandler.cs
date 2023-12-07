using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using ReminderApp.Application.Abstractions;
using ReminderApp.Application.Abstractions.Services;
using ReminderApp.Domain.Constats;
using ReminderApp.Domain.Entities;

namespace ReminderApp.Application.Features.Commands.Comment.AddComment
{
    public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJwtTokenService _jwtTokenService;
        public AddCommentCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IJwtTokenService jwtTokenService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<bool> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            string? email = _httpContextAccessor.HttpContext.Session.GetString(ReminderApp.Domain.Constats.TableProperty.Email);

            if (email is null)
            {
                var tokenUser = await _jwtTokenService.GetUserWithTokenAsync(_jwtTokenService.GetTokenInHeader());
                email = tokenUser.Email;
            }
             
            if (email is not null)
            {
                ReminderApp.Domain.Entities.User? user = await _unitOfWork.GetReadRepository<ReminderApp.Domain.Entities.User>().GetAsync(u => u.Email == email);

                ReminderApp.Domain.Entities.Comment comment = new() { Star = request.AddCommentDto.Star, UserComment = request.AddCommentDto.UserComment, Id = Guid.NewGuid(), CreatedDate = DateTime.Now, isActive = true, UserId = user.Id };

                if (user is not null)
                {
                    ReminderApp.Domain.Entities.Comment? existComment = await _unitOfWork.GetReadRepository<ReminderApp.Domain.Entities.Comment>().GetAsync(c => c.UserId == user.Id);

                    if (existComment is null)
                    {
                        comment.UserId = user.Id;
                        return await _unitOfWork.GetWriteRepository<ReminderApp.Domain.Entities.Comment>().CreateAsync(comment) ? await _unitOfWork.SaveChangesAsync() > 0 : false;
                    }

                    existComment.UserComment = request.AddCommentDto.UserComment;
                    existComment.Star = request.AddCommentDto.Star;
                    return _unitOfWork.GetWriteRepository<ReminderApp.Domain.Entities.Comment>().UpdateAsync(existComment) ? await _unitOfWork.SaveChangesAsync() > 0 : false;
                }
            }
            return false;
        }
    }
}
