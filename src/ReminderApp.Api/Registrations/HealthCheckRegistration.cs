namespace ReminderApp.Api.Registrations
{

    public static class HealthCheck
    {
        public static IServiceCollection HealthCheckRegistration(this IServiceCollection services)
        {
            services.AddHealthChecks();

            return services;
        }

        public static WebApplication HealthCheckRegistrationApp(this WebApplication app)
        {
            //app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health");
            });

            return app;
        }
    }

}
