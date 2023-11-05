using Microsoft.Extensions.DependencyInjection;
using ReminderApp.Application.Registrations;

namespace ReminderApp.Application
{
    public static class Dependency
    {
        public static IServiceCollection ApplicationDependencyInjection(this IServiceCollection services)
        {
            services.MapperRegistration();

            services.MediatrRegistration();

            services.ValidationRegistration();

            return services;
        }
    }
}
