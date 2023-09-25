using Microsoft.Extensions.DependencyInjection;

namespace Marvel.Infra.IoC.BootstrapServices;

public static class BootstrapService
{
    public static IServiceCollection AddBootstrapServices(this IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddDistributedMemoryCache();

        return services;
    }
}