using Marvel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marvel.Infra.Data.Mappings;

public class CharacterConfiguration : IEntityTypeConfiguration<Character>
{
    public void Configure(EntityTypeBuilder<Character> builder)
    {
        builder.ToTable("Characters");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(1000);
        builder.Property(x => x.Modified).IsRequired();
        builder.Property(x => x.ResourceUri).HasMaxLength(1000);
        
        builder.HasOne(x => x.Thumbnail)
            .WithOne()
            .HasForeignKey<Thumbnail>(x => x.Id);
    }
}