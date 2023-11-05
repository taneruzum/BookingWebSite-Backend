using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ReminderApp.Application.Registrations
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
