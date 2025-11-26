using Internet_shop.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Internet_shop.Infrastructure.Configurations;

internal class ProductSpecificationEntityConfiguration : IEntityTypeConfiguration<ProductSpecificationEntity>
{
    public void Configure(EntityTypeBuilder<ProductSpecificationEntity> builder)
    {
        builder.ToTable("ProductSpecifications");

        builder.HasKey(p => new { p.ProductId, p.SpecificationId });

        builder.HasOne(p => p.Product)
            .WithMany(p => p.SpecificationList)
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(p => p.ProductId)
            .IsRequired()
            .HasColumnName("product_fk");

        builder.HasOne(p => p.Specification)
            .WithMany()
            .HasForeignKey(p => p.SpecificationId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(p => p.SpecificationId)
            .IsRequired()
            .HasColumnName("specification_fk");

        builder.HasOne(p => p.SpecificationValue)
            .WithMany()
            .HasForeignKey(p => p.SpecificationValueId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(p => p.SpecificationValueId)
            .IsRequired()
            .HasColumnName("specification_value_fk");
    }
}
