using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ReminderApp.Persistence.Data;

namespace ReminderApp.Persistence.Registrations
{
    public static class Seed
    {
        public static IServiceCollection SeedRegistration(this IServiceCollection services, IServiceProvider serviceProvider)
        {
            var mediatr = serviceProvider.GetRequiredService<IMediator>();

            var context = serviceProvider.GetRequiredService<ReminderDbContext>();

            services.AddTransient(sp =>
            {
                return new ReminderDataSeed(mediatr, context);
            });

            return services;
        }

        public static WebApplication SeedRegistrationApp(this WebApplication app)
        {
            var scopeFactory = app.Services.GetService<IServiceScopeFactory>();

            using (var scope = scopeFactory.CreateScope())
            {
                var service = scope.ServiceProvider.GetService<ReminderDataSeed>();
                service.Seed();
            }

            return app;
        }
    }
}
