using Marvel.Application.Abstractions.Interfaces;
using Marvel.Domain.Repositories;
using Marvel.Infra.Data.Contexts;
using Marvel.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Marvel.Infra.Data.Common;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MarvelDbContext>((serviceProvider, options) =>
        {
            options.UseLoggerFactory(serviceProvider.GetRequiredService<ILoggerFactory>());

            options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            
            options.EnableSensitiveDataLogging();
            options.EnableDetailedErrors();
        });
        
        services.AddScoped<MarvelDbContextInitializer>();
        
        services.AddScoped<MarvelDbContext>();
        services.AddScoped<MarvelDbContextInitializer>();
        
        services.AddTransient<ICharacterRepository, CharacterRepository>();
        
        return services;
    }
}