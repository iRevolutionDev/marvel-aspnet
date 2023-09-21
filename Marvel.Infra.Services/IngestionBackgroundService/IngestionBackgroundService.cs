using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Marvel.Infra.Services.IngestionBackgroundService;

public class IngestionBackgroundService : BackgroundService
{
    private readonly ILogger<IngestionBackgroundService> _logger;
    
    public IngestionBackgroundService(ILogger<IngestionBackgroundService> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("IngestionBackgroundService is starting");

        stoppingToken.Register(() => _logger.LogInformation("IngestionBackgroundService is stopping"));

        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("IngestionBackgroundService is doing background work");
            
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }

        _logger.LogInformation("IngestionBackgroundService is stopping");
    }
}