using MediatR;
using ReminderApp.Application.Abstractions.Services;

namespace ReminderApp.Application.Features.Commands.User.UserImageAdd
{
    public class UserImageAddCommandHandler : IRequestHandler<UserImageAddCommand, bool>
    {
        private readonly IImageService _imageService;
        private readonly IJwtTokenService _jwtTokenService;

        public UserImageAddCommandHandler(IImageService imageService, IJwtTokenService jwtTokenService)
        {
            _imageService = imageService;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<bool> Handle(UserImageAddCommand request, CancellationToken cancellationToken)
        {
            ReminderApp.Domain.Entities.User? user = await _jwtTokenService.GetUserWithTokenAsync(request.token);
            bool dbResponse = await _imageService.AddImageToUserAsync(user, request.FileUpload);
            return dbResponse;
        }
    }
}
