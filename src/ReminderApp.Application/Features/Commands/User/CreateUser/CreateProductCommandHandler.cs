using AutoMapper;
using MediatR;
using ReminderApp.Application.Abstractions;
using ReminderApp.Application.Abstractions.Services;
using ReminderApp.Application.Exceptions.User;

namespace ReminderApp.Application.Features.Commands.User.CreateUser
{
    public class CreateProductCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHashService _hashService;

        public CreateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHashService hashService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _hashService = hashService;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            request.createUserDto.Password = _hashService.StringHashingEncrypt(request.createUserDto.Password);

            bool resultAny = await _unitOfWork.GetReadRepository<ReminderApp.Domain.Entities.User>().AnyAsync(u => u.Email == request.createUserDto.Email);

            if (resultAny)
                throw new UserAlreadyExistsException(request.createUserDto.Fullname);

            bool result = await _unitOfWork.GetWriteRepository<ReminderApp.Domain.Entities.User>().CreateAsync(_mapper.Map<ReminderApp.Domain.Entities.User>(request.createUserDto));

            int dbResult = await _unitOfWork.SaveChangesAsync();

            return dbResult <= 0 ? false : true;
        }
    }
}
