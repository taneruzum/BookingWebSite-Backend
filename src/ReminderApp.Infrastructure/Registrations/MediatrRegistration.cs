using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ReminderApp.Infrastructure.Registrations
{
    public static class Mediatr
    {
        public static IServiceCollection MediatrRegistration(this IServiceCollection services)
        {
            services.AddMediatR(AssemblyReference.Assembly);

            return services;
        }
    }
}
