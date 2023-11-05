using System.Reflection.Metadata.Ecma335;

namespace ReminderApp.Api.Registrations
{
    public static class Session
    {
        public static IServiceCollection SessionRegistration(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();

            services.AddSession();

            return services;
        }
    }
}
