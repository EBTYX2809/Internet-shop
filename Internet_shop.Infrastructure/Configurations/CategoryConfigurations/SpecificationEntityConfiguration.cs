using Internet_shop.Infrastructure.Entities.CategoryEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Internet_shop.Infrastructure.Configurations.CategoryConfigurations;

internal class SpecificationEntityConfiguration : IEntityTypeConfiguration<SpecificationEntity>
{
    public void Configure(EntityTypeBuilder<SpecificationEntity> builder)
    {
        builder.ToTable("Specifications");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
            .IsRequired()
            .ValueGeneratedOnAdd()
            .HasColumnName("id");

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("name");

        builder.HasIndex(s => s.Name).IsUnique();

        builder.HasOne(s => s.SubCategory)
            .WithMany(c => c.Specifications)
            .HasForeignKey(s => s.SubCategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(s => s.SubCategoryId)
            .IsRequired()
            .HasColumnName("subcategory_fk");
    }
}