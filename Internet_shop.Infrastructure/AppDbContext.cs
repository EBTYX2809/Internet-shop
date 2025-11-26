using Internet_shop.Domain.Models;
using Internet_shop.Infrastructure.Configurations;
using Internet_shop.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Internet_shop.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductReview> ProductReviews { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<Order> Orders { get; set; }    

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
