using ReminderApp.Domain.Entities;
using ReminderApp.Domain.Models;

namespace ReminderApp.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<bool> UpdateRefreshTokenAsync(string refreshToken, User User, DateTime accessTokenDate, int refreshTokenLifeTimeSecond);

        Task<Token> RefreshTokenLoginAsync(string refreshToken);
    }
}
