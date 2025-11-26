using Internet_shop.Domain.Models;
using Internet_shop.Infrastructure.Configurations;
using Internet_shop.Infrastructure.Entities;
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
        modelBuilder.ApplyConfiguration<UserEntity>(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration<ProductEntity>(new ProductEntityConfiguration());
        modelBuilder.ApplyConfiguration<ProductReviewEntity>(new ProductReviewEntityConfiguration());
        modelBuilder.ApplyConfiguration<ShoppingCartItemEntity>(new ShoppingCartItemEntityConfiguration());
        modelBuilder.ApplyConfiguration<OrderEntity>(new OrderEntityConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
