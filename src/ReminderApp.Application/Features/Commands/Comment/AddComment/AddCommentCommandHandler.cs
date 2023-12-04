using MediatR;

namespace ReminderApp.Application.Features.Commands.Comment.AddComment
{
    public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand, bool>
    {
        //private readonly IMapper _mapper;
        //private readonly IUnitOfWork _unitOfWork;
        //private readonly ISession _session;
        //public AddCommentCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, ISession session)
        //{
        //    _mapper = mapper;
        //    _unitOfWork = unitOfWork;
        //    _session = session;
        //}

        //public async Task<bool> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        //{
        //    ReminderApp.Domain.Entities.Comment comment = _mapper.Map<ReminderApp.Domain.Entities.Comment>(request.AddCommentDto);

        //    byte[]? emailBytes = _session.Get("Email");
        //    if (emailBytes is not null)
        //    {
        //        string userMail = Encoding.UTF8.GetString(emailBytes);
        //        ReminderApp.Domain.Entities.User? user = await _unitOfWork.GetReadRepository<ReminderApp.Domain.Entities.User>().GetAsync(u => u.Email == userMail);

        //        if (user is not null)
        //        {
        //            comment.UserId = user.Id;
        //            await _unitOfWork.GetWriteRepository<ReminderApp.Domain.Entities.Comment>().CreateAsync(comment);
        //            return await _unitOfWork.SaveChangesAsync() > 0;
        //        }
        //    }
        //    return false;
        //}
        public Task<bool> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
