using Marvel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marvel.Infra.Data.Mappings;

public class ComicListConfiguration : IEntityTypeConfiguration<ComicList>
{
    public void Configure(EntityTypeBuilder<ComicList> builder)
    {
        builder.ToTable("ComicLists");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Available).IsRequired();
        builder.Property(x => x.Returned).IsRequired();
        builder.Property(x => x.CollectionUri).IsRequired();
    }
}