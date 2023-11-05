using Microsoft.Extensions.DependencyInjection;
using ReminderApp.Application.Abstractions;
using ReminderApp.Persistence.Data;
using ReminderApp.Persistence.Repositories.Generic;

namespace ReminderApp.Persistence.Registrations
{
    public static class Generic
    {
        public static IServiceCollection GenericRegistration(this IServiceCollection services)
        {
            var sp = GetProvider(services);

            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));

            var context = sp.GetRequiredService<ReminderDbContext>();

            services.AddScoped(sp =>
            {
                return new UnitOfWork(context);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static ServiceProvider GetProvider(IServiceCollection services)
        {
            return services.BuildServiceProvider();
        }
    }
}
