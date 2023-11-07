using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ReminderApp.Application.Abstractions;
using ReminderApp.Application.Abstractions.Services;
using ReminderApp.Domain.Constats;
using ReminderApp.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ReminderApp.Persistence.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IDateTimeService _dateTimeService;
        private readonly IUnitOfWork _unitOfWork;
        public JwtTokenService(IConfiguration configuration, IDateTimeService dateTimeService, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _dateTimeService = dateTimeService;
            _unitOfWork = unitOfWork;
        }

        public string GenerateToken(User user)
        {
            var siginingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"])),
                SecurityAlgorithms.HmacSha256
            );

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName,user.Email),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role,Roles.UserRole)
            };

            var securityToken = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                expires: _dateTimeService.UtcNow.AddMinutes(double.Parse(_configuration["JwtSettings:ExpiryMinutes"])),
                claims: claims,
                signingCredentials: siginingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

        public async Task<User> GetUserWithTokenAsync(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var readToken = tokenHandler.ReadJwtToken(token);

            var emailClaim = readToken.Claims.FirstOrDefault(claim => claim.Type == TableProperty.email);

            if (emailClaim != null)
                return await _unitOfWork.GetReadRepository<User>().GetAsync(u => u.Email == emailClaim.Value);
            else
                return null;
        }
    }
}
