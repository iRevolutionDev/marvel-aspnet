using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Marvel.Infra.Data.Contexts;

public static class MarvelDbContextInitializerExtensions
{
    public static async Task InitializeAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var initializer = scope.ServiceProvider.GetRequiredService<MarvelDbContextInitializer>();
        
        await initializer.InitializeAsync();
    }
}

public class MarvelDbContextInitializer
{
    private readonly ILogger<MarvelDbContextInitializer> _logger;
    private readonly MarvelDbContext _context;
    
    public MarvelDbContextInitializer(ILogger<MarvelDbContextInitializer> logger, MarvelDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    
    public async Task InitializeAsync()
    {
        try
        {
            _logger.LogInformation("Initializing database...");
        
            await _context.Database.MigrateAsync();
        
            _logger.LogInformation("Database initialized");
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred while migrating or initializing the database");
            throw;
        }
    }
}