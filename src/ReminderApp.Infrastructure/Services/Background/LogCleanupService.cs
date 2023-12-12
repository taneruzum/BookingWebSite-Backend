using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ReminderApp.Domain.Constats;
using Serilog;

namespace ReminderApp.Infrastructure.Services.Background
{
    public class LogCleanupService : BackgroundService
    {
        private readonly ILogger<LogCleanupService> _logger;
        private readonly TimeSpan _cleanupInterval = TimeSpan.FromDays(2);
        private readonly IConfiguration _configuration;

        public LogCleanupService(ILogger<LogCleanupService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Log.CloseAndFlush();
                try
                {
                    _logger.LogInformation("Clearing the Log File...");
                    if (FilePaths.txtLogFiles is not null)
                    {
                        foreach (var file in FilePaths.txtLogFiles)
                            File.Delete(file);
                        _logger.LogInformation("Log file cleared.");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error formed clearing the log file: {ex.Message}");
                }
                Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(_configuration).CreateLogger();
                await Task.Delay(_cleanupInterval, stoppingToken);
            }
        }
    }
}
