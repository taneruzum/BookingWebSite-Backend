using MediatR;
using ReminderApp.Application.Abstractions;
using ReminderApp.Application.Abstractions.Services;
using ReminderApp.Domain.Entities;

namespace ReminderApp.Application.Features.Queries.User.UserImageGet
{
    public class UserImageGetQueryCommand : IRequestHandler<UserImageGetQuery, Image>
    {
        private readonly IImageService _imageService;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IUnitOfWork _unitOfWork;

        public UserImageGetQueryCommand(IImageService imageService, IJwtTokenService jwtTokenService, IUnitOfWork unitOfWork)
        {
            _imageService = imageService;
            _jwtTokenService = jwtTokenService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Image> Handle(UserImageGetQuery request, CancellationToken cancellationToken)
        {
            ReminderApp.Domain.Entities.User? user = await _jwtTokenService.GetUserWithTokenAsync(request.token);

            List<ImageUser>? imageUser = await _unitOfWork.GetReadRepository<ImageUser>().GetAllAsync(iu => iu.UserId == user.Id);

            Image? image = await _imageService.GetImageAsync(imageUser.FirstOrDefault().ImageId);

            return image;
        }
    }
}
