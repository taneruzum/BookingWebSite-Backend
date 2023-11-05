namespace ReminderApp.Api.Registrations
{
    public static class Cors
    {
        public static IServiceCollection CorsRegistration(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:7265")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                    });
            });

            return services;
        }

        public static WebApplication CorsRegistrationApp(this WebApplication app)
        {
            app.UseCors("AllowOrigin");

            return app;
        }
    }
}
