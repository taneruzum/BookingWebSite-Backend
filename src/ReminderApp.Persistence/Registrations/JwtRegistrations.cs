using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ReminderApp.Application.Abstractions;
using ReminderApp.Application.Abstractions.Services;
using ReminderApp.Persistence.Services;
using System.Text;

namespace ReminderApp.Persistence.Registrations
{
    public static class Jwt
    {
        public static IServiceCollection JwtRegistrations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["JwtSettings:Secret"])
                    ),
                    LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false
                })
                .AddCookie("default");

            var sp = GetProvider(services);
            var dateService = sp.GetRequiredService<IDateTimeService>();
            var unitofworkService = sp.GetRequiredService<IUnitOfWork>();
            var httpContextAcc = sp.GetRequiredService<IHttpContextAccessor>();

            services.AddScoped<IJwtTokenService>(sp =>
            {
                return new JwtTokenService(configuration, dateService, unitofworkService, httpContextAcc);
            });

            return services;
        }

        public static ServiceProvider GetProvider(IServiceCollection services)
        {
            return services.BuildServiceProvider();
        }
    }
}
