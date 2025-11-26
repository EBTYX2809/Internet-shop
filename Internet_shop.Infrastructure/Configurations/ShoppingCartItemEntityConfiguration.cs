using Internet_shop.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Internet_shop.Infrastructure.EntityConfigurations;

internal class ShoppingCartItemEntityConfiguration : IEntityTypeConfiguration<ShoppingCartItemEntity>
{
    public void Configure(EntityTypeBuilder<ShoppingCartItemEntity> builder)
    {
        builder.ToTable("ShoppingCarts");

        builder.HasKey(c => c.Id);

        builder.Property(u => u.Id)
            .IsRequired()
            .ValueGeneratedOnAdd()
            .HasColumnName("id");

        builder.HasOne(c => c.User)
            .WithMany(u => u.ShoppingCart)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(t => t.UserId)
            .IsRequired()
            .HasColumnName("user_fk");

        builder.HasOne(c => c.Product)
            .WithMany()
            .HasForeignKey(c => c.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(t => t.ProductId)
            .IsRequired()
            .HasColumnName("product_fk");
    }
}