
using Microsoft.Extensions.DependencyInjection;

namespace ReminderApp.Application.Registrations
{
    public static class Mapper
    {
        public static IServiceCollection MapperRegistration(this IServiceCollection services)
        {
            services.AddAutoMapper(AssemblyReference.Assembly);

            return services;
        }
    }
}
