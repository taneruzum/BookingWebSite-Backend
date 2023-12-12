using ReminderApp.Domain.Entities;
using ReminderApp.Domain.Models;

namespace ReminderApp.Application.Abstractions.Services
{
    public interface IJwtTokenService
    {
        Token GenerateToken(User user);
        Task<User> GetUserWithTokenAsync(string token);
        string GetTokenInHeader();
    }
}
