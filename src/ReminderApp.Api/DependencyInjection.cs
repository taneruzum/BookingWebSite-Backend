using ReminderApp.Api.Registrations;

namespace ReminderApp.Api
{
    public static class Dependency
    {
        public static IServiceCollection ApiDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.HealthCheckRegistration();

            //services.SessionRegistration();

            services.ControllerRegistration();

            services.CorsRegistration();

            services.SwaggerRegistration();

            return services;
        }

        public static WebApplication ApiDependencyApp(this WebApplication app)
        {
            app.CorsRegistrationApp();

            //app.SessionRegistrationApp();

            app.SwaggerRegistrationApp();

            //app.HealthCheckRegistrationApp();

            return app;
        }
    }
}
