using Internet_shop.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Internet_shop.Infrastructure.Configurations;

internal class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(p => p.Id);

        builder.Property(u => u.Id)
            .IsRequired()
            .ValueGeneratedOnAdd()
            .HasColumnName("id");

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("name");

        builder.HasIndex(p => p.Name).IsUnique();

        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("description");

        builder.Property(p => p.Price)
            .HasColumnType("decimal(12,2)")
            .IsRequired()
            .HasColumnName("price");

        builder.HasIndex(p => p.Price);

        builder.Property(p => p.Rating)
            .HasDefaultValue(0)
            .HasColumnName("rating");

        builder.HasIndex(p => p.Rating);

        builder.HasOne(p => p.Category)
            .WithMany()
            .HasForeignKey(p => p.Category.Id)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(p => p.Category.Id)
            .IsRequired()
            .HasColumnName("category_fk");

        builder.HasOne(p => p.SubCategory)
            .WithMany()
            .HasForeignKey(p => p.SubCategory.Id)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(p => p.SubCategory.Id)
            .IsRequired()
            .HasColumnName("subcategory_fk");
    }
}