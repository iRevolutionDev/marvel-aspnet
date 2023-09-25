using Microsoft.Extensions.DependencyInjection;
using Marvel.Infra.Services.IngestionBackgroundService;

namespace Marvel.Infra.Services.Common;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraBackgroundServices(this IServiceCollection services)
    {
        services.AddHostedService<IngestionBackgroundService.IngestionBackgroundService>();
        
        return services;
    }
}