using MediatR;
using Microsoft.Extensions.Configuration;
using ReminderApp.Application.Abstractions;
using ReminderApp.Application.Abstractions.Services;
using ReminderApp.Application.Exceptions.User;

namespace ReminderApp.Application.Features.Commands.User.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, (bool isSuccess, string token)>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IHashService _hashService;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public LoginUserCommandHandler(IUnitOfWork unitOfWork, IJwtTokenService jwtTokenService, IHashService hashService, IUserService userService, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _jwtTokenService = jwtTokenService;
            _hashService = hashService;
            _userService = userService;
            _configuration = configuration;
        }

        public async Task<(bool isSuccess, string token)> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            request.loginUserDto.Password = _hashService.StringHashingEncrypt(request.loginUserDto.Password);

            bool dbResult = await _unitOfWork.GetReadRepository<ReminderApp.Domain.Entities.User>().AnyAsync(u => u.Email == request.loginUserDto.Email && u.Password == request.loginUserDto.Password);

            if (dbResult is false)
                throw new UserNotExistsException(request.loginUserDto.Email);

            var user = await _unitOfWork.GetReadRepository<ReminderApp.Domain.Entities.User>().GetAsync(u => u.Email == request.loginUserDto.Email);

            var token = _jwtTokenService.GenerateToken(user);

            await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, int.Parse(_configuration["JwtSettings:ExpireMinuteRefToken"]));

            return (dbResult, token.AccessToken);
        }
    }
}
