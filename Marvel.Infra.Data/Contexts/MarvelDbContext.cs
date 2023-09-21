using System.Reflection;
using Marvel.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Marvel.Infra.Data.Contexts;

public class MarvelDbContext : DbContext
{
    public MarvelDbContext(DbContextOptions<MarvelDbContext> options, DbSet<ComicList> comics) : base(options) {}
    
    public DbSet<ComicList> Comics => Set<ComicList>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(modelBuilder);
    }
}