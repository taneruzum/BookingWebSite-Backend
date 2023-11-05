using ReminderApp.Domain.Entities;

namespace ReminderApp.Application.Abstractions.Services
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user);

        Task<User> GetUserWithTokenAsync(string token);
    }
}
