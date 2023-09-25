using Marvel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marvel.Infra.Data.Mappings;

public class ComicSummaryConfiguration : IEntityTypeConfiguration<ComicSummary>
{
    public void Configure(EntityTypeBuilder<ComicSummary> builder)
    {
        builder.ToTable("ComicSummaries");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.ResourceUri).IsRequired();
        builder.Property(x => x.Name).IsRequired();
    }
}