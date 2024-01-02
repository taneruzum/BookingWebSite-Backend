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
            var sp = GetProvider(services);

            services.AddScoped<IDateTimeService, DateTimeService>();

            services.AddScoped<IPubEventService, PubEventService>();

            services.AddScoped<IImageService, ImageService>();

            services.AddScoped<IHashService>(sp =>
            {
                return new HashService(configuration);
            });

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IMeetingService, MeetingService>();

            return services;
        }

        public static ServiceProvider GetProvider(IServiceCollection services)
        {
            return services.BuildServiceProvider();
        }
    }
}
