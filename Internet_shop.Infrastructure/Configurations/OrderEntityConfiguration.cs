using Internet_shop.Domain.Models;
using Internet_shop.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Internet_shop.Infrastructure.Configurations;

internal class OrderEntityConfiguration : IEntityTypeConfiguration<OrderEntity>
{
    public void Configure(EntityTypeBuilder<OrderEntity> builder)
    {
        builder.ToTable("Orders");

        builder.HasKey(o => o.Id);

        builder.Property(u => u.Id)
            .IsRequired()
            .ValueGeneratedOnAdd()
            .HasColumnName("id");

        builder.Property(o => o.CreatedDate)
            .HasColumnName("created_date")
            .IsRequired();

        builder.Property(o => o.DeliveredDate)
            .HasColumnName("delivered_date")
            .IsRequired(false);

        builder.Property(o => o.SummaryPrice)
            .HasColumnType("decimal(18,2)")
            .HasColumnName("summary_price")
            .IsRequired();

        builder.HasOne(o => o.User)
            .WithMany(u => u.OrdersHistory)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(o => o.UserId)
            .HasColumnName("user_fk")
            .IsRequired();
    }
}