using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReminderApp.Infrastructure.Registrations;

namespace ReminderApp.Infrastructure
{
    public static class Dependency
    {
        public static IServiceCollection InfrastructureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.SignalRRegistration();

            services.ServiceRegistration();

            services.LoggerRegistration(configuration);

            return services;
        }

        public static WebApplicationBuilder InfrastructureDependencyInjectionBuilder(this WebApplicationBuilder builder, IConfiguration configuration)
        {

            builder.LoggerRegistrationBuilder(configuration);

            return builder;
        }

        public static WebApplication InfrastructureDependencyInjectionApp(this WebApplication app)
        {
            app.MiddlewareRegistrationApp();

            app.LoggerRegistrationApp();

            app.HubRegistrationApp();

            return app;
        }

        ////string email = Encoding.UTF8.GetString(emailBytes);
    }
}
