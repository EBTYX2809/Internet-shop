using Internet_shop.Domain.Models;
using Internet_shop.Infrastructure.Configurations;
using Internet_shop.Infrastructure.Entities;
using Internet_shop.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Internet_shop.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    internal DbSet<UserEntity> Users { get; set; }
    internal DbSet<ShoppingCartItemEntity> ShoppingCarts { get; set; }
    internal DbSet<ProductEntity> Products { get; set; }
    internal DbSet<ProductSpecificationEntity> ProductSpecifications { get; set; }
    internal DbSet<ProductReviewEntity> ProductReviews { get; set; }
    internal DbSet<CategoryEntity> Categories { get; set; }
    internal DbSet<SubCategoryEntity> SubCategories { get; set; }
    internal DbSet<SpecificationEntity> Specifications { get; set; }
    internal DbSet<SpecificationValueEntity> SpecificationValues { get; set; }
    internal DbSet<OrderEntity> Orders { get; set; }    
    internal DbSet<OrderItemEntity> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {        
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ShoppingCartItemEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ProductSpecificationEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ProductReviewEntityConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
        modelBuilder.ApplyConfiguration(new SubCategoryEntityConfiguration());
        modelBuilder.ApplyConfiguration(new SpecificationEntityConfiguration());
        modelBuilder.ApplyConfiguration(new SpecificationValueEntityConfiguration());        
        modelBuilder.ApplyConfiguration(new OrderEntityConfiguration());
        modelBuilder.ApplyConfiguration(new OrderItemEntityConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
