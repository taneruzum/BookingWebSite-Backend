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
        private readonly IImageService _imageService;

        public CreateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHashService hashService, IImageService imageService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _hashService = hashService;
            _imageService = imageService;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            request.createUserDto.Password = _hashService.StringHashingEncrypt(request.createUserDto.Password);

            bool resultAny = await _unitOfWork.GetReadRepository<ReminderApp.Domain.Entities.User>().AnyAsync(u => u.Email == request.createUserDto.Email);

            if (resultAny)
                throw new UserAlreadyExistsException(request.createUserDto.Email);

            var user = _mapper.Map<ReminderApp.Domain.Entities.User>(request.createUserDto);

            bool result = await _unitOfWork.GetWriteRepository<ReminderApp.Domain.Entities.User>().CreateAsync(user);

            int dbResult = await _unitOfWork.SaveChangesAsync();

            await _imageService.AssignUserDefaultImage(user);

            return dbResult <= 0 ? false : true;
        }
    }
}
