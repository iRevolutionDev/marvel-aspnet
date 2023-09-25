using Marvel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marvel.Infra.Data.Mappings;

public class StoriesListConfiguration : IEntityTypeConfiguration<StoriesList>
{
    public void Configure(EntityTypeBuilder<StoriesList> builder)
    {
        builder.ToTable("StoriesLists");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Available).IsRequired();
        builder.Property(x => x.Returned).IsRequired();
        builder.Property(x => x.CollectionUri).IsRequired();
    }
}