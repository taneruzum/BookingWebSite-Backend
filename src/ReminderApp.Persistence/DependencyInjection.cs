using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReminderApp.Persistence.Data;
using ReminderApp.Persistence.Registrations;

namespace ReminderApp.Persistence
{
    public static class Dependency
    {
        public static IServiceCollection PersistenceDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.DatabaseRegistration(configuration);

            services.RepositoryRegistration();

            services.ServiceRegistrations(configuration);

            services.GenericRegistration();

            services.JwtRegistrations(configuration);

            services.SeedRegistration(services.BuildServiceProvider());

            return services;
        }

        public static WebApplication PersistenceInjectionApp(this WebApplication app)
        {
            app.SeedRegistrationApp();

            return app;
        }
    }
}
