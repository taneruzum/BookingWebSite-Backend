using Microsoft.Extensions.DependencyInjection;
using ReminderApp.Application.Abstractions;
using ReminderApp.Application.Abstractions.Repositories.Read;
using ReminderApp.Application.Abstractions.Repositories.Write;
using ReminderApp.Application.Abstractions.Services;
using ReminderApp.Persistence.Data;
using ReminderApp.Persistence.Repositories.Generic;
using ReminderApp.Persistence.Repositories.ReadRepository;
using ReminderApp.Persistence.Repositories.WriteRepository;

namespace ReminderApp.Persistence.Registrations
{
    public static class Generic
    {
        public static IServiceCollection GenericRegistration(this IServiceCollection services)
        {
            var sp = GetProvider(services);

            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));

            //services.AddScoped<IUserReadRepository, UserReadRepository>();
            //services.AddScoped<IUserWriteRepository, UserWriteRepository>();

            //services.AddScoped<ICommentReadRepository, CommentReadRepository>();
            //services.AddScoped<ICommentWriteRepository, CommentWriteRepository>();

            var context = sp.GetRequiredService<ReminderDbContext>();
            var pubEventService = sp.GetRequiredService<IPubEventService>();

            services.AddScoped<IUnitOfWork>(sp =>
            {
                return new UnitOfWork(context, pubEventService);
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
