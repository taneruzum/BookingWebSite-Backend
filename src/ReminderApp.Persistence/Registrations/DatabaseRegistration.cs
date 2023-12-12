using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReminderApp.Persistence.Data;

namespace ReminderApp.Persistence.Registrations
{
    public static class Database
    {
        public static IServiceCollection DatabaseRegistration(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ReminderDbContext>(options =>
            {
                options.UseSqlServer(configuration["DatabaseConnection:DbUrl"],
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(AssemblyReference.Assembly.GetName().Name);
                    sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: System.TimeSpan.FromSeconds(30), null);
                });
            }, ServiceLifetime.Singleton);

            var optionsBuilder = new DbContextOptionsBuilder<ReminderDbContext>().UseSqlServer(configuration["DatabaseConnection:DbUrl"]);

            using var dbContext = new ReminderDbContext(optionsBuilder.Options);

            dbContext.Database.EnsureCreated();

            dbContext.Database.Migrate();

            return services;
        }
    }
}
