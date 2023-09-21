using Marvel.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Marvel.Infra.Data.Common;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MarvelDbContext>((serviceProvider, options) =>
        {
            // TODO: Add interceptors to log queries etc...
            
            options.UseSqlite();
        });
        
        services.AddScoped<MarvelDbContext>();
        services.AddScoped<MarvelDbContextInitializer>();
        
        return services;
    }
}