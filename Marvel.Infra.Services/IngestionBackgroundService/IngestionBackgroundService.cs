using Marvel.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Marvel.Infra.Services.IngestionBackgroundService;

public class IngestionBackgroundService : BackgroundService
{
    private readonly ILogger<IngestionBackgroundService> _logger;
    private readonly IServiceScopeFactory _serviceScopeFactory;
    
    public IngestionBackgroundService(ILogger<IngestionBackgroundService> logger, IServiceScopeFactory serviceScopeFactory)
    {
        _logger = logger;
        _serviceScopeFactory = serviceScopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("IngestionBackgroundService is starting");

        stoppingToken.Register(() => _logger.LogInformation("IngestionBackgroundService is stopping"));

        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("IngestionBackgroundService is doing background work");
            
            using var scope = _serviceScopeFactory.CreateScope(); // Create a new scope to resolve scoped services
            
            var marvelApiService = scope.ServiceProvider.GetRequiredService<MarvelApiService>();
            
            _logger.LogInformation("Ingesting characters from Marvel API");
            
            // Ingest characters from Marvel API
            await marvelApiService.IngestCharactersAsync();
            
            await Task.Delay(TimeSpan.FromMinutes(30), stoppingToken);
        }

        _logger.LogInformation("IngestionBackgroundService is stopping");
    }
}