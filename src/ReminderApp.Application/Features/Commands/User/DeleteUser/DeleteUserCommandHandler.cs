using MediatR;
using ReminderApp.Application.Abstractions;
using ReminderApp.Application.Exceptions.User;

namespace ReminderApp.Application.Features.Commands.User.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            ReminderApp.Domain.Entities.User? user = await _unitOfWork.GetReadRepository<ReminderApp.Domain.Entities.User>().GetAsync(u => u.Id == request.id);

            if (user is null)
                throw new UserNotExistsException();

            user.isActive = false;

            _unitOfWork.GetWriteRepository<ReminderApp.Domain.Entities.User>().UpdateAsync(user);

            int dbResult = await _unitOfWork.SaveChangesAsync();

            return dbResult <= 0 ? false : true;
        }
    }
}
