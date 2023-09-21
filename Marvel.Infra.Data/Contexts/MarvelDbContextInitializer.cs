using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Marvel.Infra.Data.Contexts;

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

    public Task SeedAsync()
    {
        return Task.CompletedTask;
    }
}