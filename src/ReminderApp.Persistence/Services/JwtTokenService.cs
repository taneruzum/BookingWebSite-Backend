using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ReminderApp.Application.Abstractions;
using ReminderApp.Application.Abstractions.Services;
using ReminderApp.Domain.Constats;
using ReminderApp.Domain.Entities;
using ReminderApp.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ReminderApp.Persistence.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IDateTimeService _dateTimeService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JwtTokenService(IConfiguration configuration, IDateTimeService dateTimeService, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _dateTimeService = dateTimeService;
            _unitOfWork = unitOfWork;
        }

        public JwtTokenService(IConfiguration configuration, IDateTimeService dateTimeService, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _dateTimeService = dateTimeService;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public Token GenerateToken(User user)
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

            var _expries = DateTime.Now.AddMinutes(int.Parse(_configuration["JwtSettings:ExpiryMinutes"]));

            var securityToken = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                expires: _expries,
                claims: claims,
                signingCredentials: siginingCredentials
            );

            Token token = new();
            token.Expiration = _expries;
            token.AccessToken = new JwtSecurityTokenHandler().WriteToken(securityToken);
            token.RefreshToken = CreateRefreshToken();

            return token;
        }

        public async Task<User> GetUserWithTokenAsync(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var readToken = tokenHandler.ReadJwtToken(token);

            var emailClaim = readToken.Claims.FirstOrDefault(claim => claim.Type == "email");

            if (emailClaim != null)
                return await _unitOfWork.GetReadRepository<User>().GetAsync(u => u.Email == emailClaim.Value);
            else
                return null;
        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(number);
            return Convert.ToBase64String(number);
        }

        public string GetTokenInHeader()
        {
            string token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            if (token != null && token.StartsWith("Bearer "))
                return token.Substring("Bearer ".Length).Trim();
            return null;
        }
    }
}
