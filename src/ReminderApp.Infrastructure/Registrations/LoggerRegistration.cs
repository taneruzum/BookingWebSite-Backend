using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ReminderApp.Domain.Constats;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Filters;

namespace ReminderApp.Infrastructure.Registrations
{
    public static class Log
    {
        public static IServiceCollection LoggerRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog());

            Serilog.Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            return services;
        }

        public static WebApplicationBuilder LoggerRegistrationBuilder(this WebApplicationBuilder builder, IConfiguration configuration)
        {
            Serilog.Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
               .Enrich.FromLogContext()
               .Enrich.WithCorrelationId()
               .Enrich.WithExceptionDetails()
               .Filter.ByExcluding(Matching.FromSource("Microsoft.AspNetCore.StaticFiles"))
               .WriteTo.Async(writeTo => writeTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}"))
               .ReadFrom.Configuration(configuration)
               .CreateLogger();

            builder.Logging.ClearProviders();
            builder.Host.UseSerilog(Serilog.Log.Logger, true);

            return builder;
        }

        public static WebApplication LoggerRegistrationApp(this WebApplication app)
        {
            app.UseSerilogRequestLogging();

            return app;
        }
    }
}
