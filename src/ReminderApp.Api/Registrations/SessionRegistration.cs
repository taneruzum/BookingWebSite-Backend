namespace ReminderApp.Api.Registrations
{
    public static class Session
    {
        public static IServiceCollection SessionRegistration(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(300);
            });

            return services;
        }

        public static WebApplication SessionRegistrationApp(this WebApplication app)
        {
            app.UseSession();

            return app;
        }
    }
}
