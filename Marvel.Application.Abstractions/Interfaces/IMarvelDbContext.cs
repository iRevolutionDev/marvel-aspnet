using Marvel.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Marvel.Application.Abstractions.Interfaces;

public interface IMarvelDbContext
{
    public DbSet<Character> Characters { get; }
    public DbSet<ComicList> Comics { get; }
    public DbSet<ComicSummary> ComicSummaries { get; }
    public DbSet<StoriesList> Stories { get; }
    public DbSet<StorySummary> StorySummaries { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}