using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ReminderApp.Application.Abstractions.Services;
using ReminderApp.Domain.Models;
using ReminderApp.Infrastructure.Services;
using ReminderApp.Infrastructure.Services.Background;

namespace ReminderApp.Infrastructure.Registrations
{
    public static class Service
    {
        public static IServiceCollection ServiceRegistration(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<ICookieService, CookieService>();

            services.AddSingleton<INotificationQueueService, NotificationQueueService>();

            services.AddHostedService<LogCleanupService>();

            services.AddSingleton<Queue<NotificationPersonModel>>();

            services.AddSingleton<Queue<NotificationAllModel>>();

            services.AddHostedService<NotificationService>();

            return services;
        }
    }
}
