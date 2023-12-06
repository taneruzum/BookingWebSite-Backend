using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using ReminderApp.Application.Abstractions.Services;
using Serilog;

namespace ReminderApp.Infrastructure.Attributes
{
    public class UserRequestAttributeFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string authorizationHeader = context.HttpContext.Request.Headers["Authorization"];

            if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
            {
                var sp = context.HttpContext.RequestServices;

                var jwtService = sp.GetRequiredService<IJwtTokenService>();
                var cookieService = sp.GetRequiredService<ICookieService>();
                string token = authorizationHeader.Substring(7);

                var user = jwtService.GetUserWithTokenAsync(token).Result;
                cookieService.AddCookieValue("Email", user.Email);

                Log.Information($"by {user.Email} came the request !");
            }
            else
                Log.Information($"Not authorization person came the request !");
        }
    }
}
