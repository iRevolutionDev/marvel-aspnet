using Marvel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marvel.Infra.Data.Mappings;

public class StorySummaryConfiguration : IEntityTypeConfiguration<StorySummary>
{
    public void Configure(EntityTypeBuilder<StorySummary> builder)
    {
        builder.ToTable("StorySummaries");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.ResourceUri).IsRequired();
        builder.Property(x => x.Name).IsRequired();
    }
}