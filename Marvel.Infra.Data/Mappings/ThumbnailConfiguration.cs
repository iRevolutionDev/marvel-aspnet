using Marvel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marvel.Infra.Data.Mappings;

public class ThumbnailConfiguration : IEntityTypeConfiguration<Thumbnail>
{
    public void Configure(EntityTypeBuilder<Thumbnail> builder)
    {
        builder.ToTable("Thumbnails");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Path)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(x => x.Extension)
            .IsRequired()
            .HasMaxLength(10);
    }
}