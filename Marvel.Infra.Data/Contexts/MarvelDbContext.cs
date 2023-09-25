using System.Reflection;
using Marvel.Application.Abstractions.Interfaces;
using Marvel.Domain.Entities;
using Marvel.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Marvel.Infra.Data.Contexts;

public class MarvelDbContext : DbContext
{
    public MarvelDbContext(DbContextOptions<MarvelDbContext> options) : base(options) {}
    
    public DbSet<Character> Characters => Set<Character>();
    public DbSet<ComicList> Comics => Set<ComicList>();
    public DbSet<Thumbnail> Thumbnails => Set<Thumbnail>();
    public DbSet<ComicSummary> ComicSummaries => Set<ComicSummary>();
    public DbSet<StoriesList> Stories => Set<StoriesList>();
    public DbSet<StorySummary> StorySummaries => Set<StorySummary>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // Register all mappings by reflection
        
        base.OnModelCreating(modelBuilder);
    }
}