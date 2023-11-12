using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ReminderApp.Application.Abstractions.Services;

namespace ReminderApp.Infrastructure.Services
{
    public class CookieService : ICookieService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly HttpResponse _httpResponse;
        private readonly HttpRequest _httpRequest;

        public CookieService(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpResponse = _httpContextAccessor.HttpContext.Response;
            _httpRequest = _httpContextAccessor.HttpContext.Request;
        }

        public string GetCookieValue(string key) => _httpRequest.Cookies[key];

        public void AddCookieValue(string key, string value) => _httpResponse.Cookies.Append(key, value, CreateOptions());

        public void DeleteCoolie(string key) => _httpResponse.Cookies.Append(key, string.Empty, DeleteOptions());

        private CookieOptions CreateOptions()
            => new CookieOptions()
            {
                Expires = DateTime.Now.AddMinutes(int.Parse(_configuration["CookieSettings:ExpiryMinutes"])),
                SameSite = SameSiteMode.Strict
            };

        private CookieOptions DeleteOptions()
            => new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(-1),
            };
    }
}
