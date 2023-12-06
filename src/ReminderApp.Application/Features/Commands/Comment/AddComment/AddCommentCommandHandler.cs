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
            ReminderApp.Domain.Entities.Comment comment = _mapper.Map<ReminderApp.Domain.Entities.Comment>(request.AddCommentDto);

            string? email = _cookieService.GetCookieValue("Email");
            if (email is not null)
            {
                ReminderApp.Domain.Entities.User? user = await _unitOfWork.GetReadRepository<ReminderApp.Domain.Entities.User>().GetAsync(u => u.Email == email);

                if (user is not null)
                {
                    comment.UserId = user.Id;
                    await _unitOfWork.GetWriteRepository<ReminderApp.Domain.Entities.Comment>().CreateAsync(comment);
                    return await _unitOfWork.SaveChangesAsync() > 0;
                }
            }
            return false;
        }
    }
}
