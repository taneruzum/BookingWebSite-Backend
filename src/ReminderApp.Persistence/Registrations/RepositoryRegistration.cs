using Microsoft.Extensions.DependencyInjection;
using ReminderApp.Application.Abstractions.Repositories.Read;
using ReminderApp.Application.Abstractions.Repositories.Write;
using ReminderApp.Persistence.Repositories.ReadRepository;
using ReminderApp.Persistence.Repositories.WriteRepository;

namespace ReminderApp.Persistence.Registrations
{
    public static class Repository
    {
        public static IServiceCollection RepositoryRegistration(this IServiceCollection services)
        {
            services.AddScoped<IUserReadRepository, UserReadRepository>();

            services.AddScoped<IUserWriteRepository, UserWriteRepository>();

            services.AddScoped<IHubConnectionWriteRepository, HubConnectionWriteRepository>();

            services.AddScoped<IHubConnectionReadRepository, HubConnectionReadRepository>();

            return services;
        }
    }
}
