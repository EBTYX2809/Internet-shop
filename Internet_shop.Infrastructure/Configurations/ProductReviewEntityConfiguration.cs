using Internet_shop.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Internet_shop.Infrastructure.EntityConfigurations;

internal class ProductReviewEntityConfiguration : IEntityTypeConfiguration<ProductReviewEntity>
{
    public void Configure(EntityTypeBuilder<ProductReviewEntity> builder)
    {
        builder.ToTable("ProductReviews");
        
        builder.HasKey(r => new { r.ProductId, r.UserId });

        builder.HasOne(r => r.Product)
            .WithMany(p => p.Reviews)
            .HasForeignKey(r => r.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(r => r.ProductId)
            .HasColumnName("product_fk")
            .IsRequired();

        builder.HasOne(r => r.User)
            .WithMany()
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(r => r.UserId)
            .HasColumnName("user_fk")
            .IsRequired();

        builder.Property(r => r.Score)
            .HasColumnType("smallint")
            .IsRequired()
            .HasColumnName("score");

        builder.Property(r => r.Review)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("review");        
    }
}