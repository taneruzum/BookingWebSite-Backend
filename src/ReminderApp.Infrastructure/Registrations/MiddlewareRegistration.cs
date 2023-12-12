using Microsoft.AspNetCore.Builder;
using ReminderApp.Infrastructure.Middlewares;

namespace ReminderApp.Infrastructure.Registrations
{
    public static class Middleware
    {
        public static WebApplication MiddlewareRegistrationApp(this WebApplication app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();

            return app;
        }
    }
}
