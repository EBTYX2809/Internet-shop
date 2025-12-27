using Internet_shop.Infrastructure.Entities.CategoryEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Internet_shop.Infrastructure.Configurations.CategoryConfigurations;

internal class SpecificationValueEntityConfiguration : IEntityTypeConfiguration<SpecificationValueEntity>
{
    public void Configure(EntityTypeBuilder<SpecificationValueEntity> builder)
    {
        builder.ToTable("SpecificationValues");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
            .IsRequired()
            .ValueGeneratedOnAdd()
            .HasColumnName("id");

        builder.Property(s => s.Value)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("value");

        builder.HasIndex(s => s.Value).IsUnique();

        builder.HasOne(s => s.Specification)
            .WithMany(s => s.SpecificationValues)
            .HasForeignKey(s => s.SpecificationId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(s => s.SpecificationId)
            .IsRequired()
            .HasColumnName("specification_fk");
    }
}
