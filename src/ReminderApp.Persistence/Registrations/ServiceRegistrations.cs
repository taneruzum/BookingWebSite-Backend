using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReminderApp.Application.Abstractions.Services;
using ReminderApp.Persistence.Services;

namespace ReminderApp.Persistence.Registrations
{
    public static class Service
    {
        public static IServiceCollection ServiceRegistrations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDateTimeService, DateTimeService>();

            services.AddScoped<IHashService>(sp =>
            {
                return new HashService(configuration);
            });

            return services;
        }
    }
}
