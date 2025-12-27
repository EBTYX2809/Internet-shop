using Internet_shop.Infrastructure.Entities.CategoryEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Internet_shop.Infrastructure.Configurations.CategoryConfigurations;

internal class SubCategoryEntityConfiguration : IEntityTypeConfiguration<SubCategoryEntity>
{
    public void Configure(EntityTypeBuilder<SubCategoryEntity> builder)
    {
        builder.ToTable("SubCategories");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .IsRequired()
            .HasColumnName("id");

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("name");

        builder.HasIndex(c => c.Name).IsUnique();

        builder.HasOne(c => c.Category)
            .WithMany(c => c.SubCategories)
            .HasForeignKey(c => c.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(c => c.CategoryId)
            .IsRequired()
            .HasColumnName("category_fk");
    }
}