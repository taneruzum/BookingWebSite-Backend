using ReminderApp.Application;
using ReminderApp.Persistence;
using ReminderApp.Infrastructure;
using ReminderApp.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.ApplicationDependencyInjection();

builder.Services.PersistenceDependencyInjection(builder.Configuration);

builder.Services.InfrastructureDependencyInjection(builder.Configuration);

builder.InfrastructureDependencyInjectionBuilder(builder.Configuration);

builder.Services.ApiDependencyInjection(builder.Configuration);

var app = builder.Build();

app.InfrastructureDependencyInjectionApp();

app.UseHttpsRedirection();

app.ApiDependencyApp();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
