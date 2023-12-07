using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using ReminderApp.Application.Abstractions.Services;
using ReminderApp.Domain.Constats;
using Serilog;

namespace ReminderApp.Infrastructure.Attributes
{
    public class UserRequestAttributeFilter : ActionFilterAttribute
    {
        public override async void OnActionExecuting(ActionExecutingContext context)
        {
            string authorizationHeader = context.HttpContext.Request.Headers["Authorization"];

            if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
            {
                var sp = context.HttpContext.RequestServices;

                var jwtService = sp.GetRequiredService<IJwtTokenService>();

                string token = authorizationHeader.Substring(7);

                var user = await jwtService.GetUserWithTokenAsync(token);

                context.HttpContext.Session.SetString(TableProperty.Email, user.Email);

                Log.Information($"by {user.Email} came the request !");
            }
            else
                Log.Information($"Not authorization person came the request !");
        }
    }
}
