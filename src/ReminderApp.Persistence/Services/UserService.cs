using Microsoft.Extensions.Configuration;
using ReminderApp.Application.Abstractions.Repositories.Read;
using ReminderApp.Application.Abstractions.Repositories.Write;
using ReminderApp.Application.Abstractions.Services;
using ReminderApp.Domain.Entities;
using ReminderApp.Domain.Models;

namespace ReminderApp.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IConfiguration _configuration;

        public UserService(IUserWriteRepository userWriteRepository, IUserReadRepository userReadRepository, IJwtTokenService jwtTokenService, IConfiguration configuration)
        {
            _userWriteRepository = userWriteRepository;
            _userReadRepository = userReadRepository;
            _jwtTokenService = jwtTokenService;
            _configuration = configuration;
        }

        public async Task<Token> RefreshTokenLoginAsync(string refreshToken)
        {
            User? user = await _userReadRepository.GetAsync(u => u.RefreshToken == refreshToken);
            if (user is not null && user?.RefreshTokenEndDate > DateTime.Now)
            {
                Token token = _jwtTokenService.GenerateToken(user);
                await UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, int.Parse(_configuration["JwtSettings:ExpireMinuteRefToken"]));
                return token;
            }
            return null;
        }

        public async Task<bool> UpdateRefreshTokenAsync(string refreshToken, User User, DateTime accessTokenDate, int refreshTokenLifeTimeSecond)
        {
            if (User is not null)
            {
                User.RefreshToken = refreshToken;
                User.RefreshTokenEndDate = accessTokenDate.AddMinutes(refreshTokenLifeTimeSecond);

                _userWriteRepository.UpdateAsync(User);
                await _userWriteRepository.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
