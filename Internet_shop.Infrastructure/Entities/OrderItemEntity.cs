namespace Internet_shop.Infrastructure.Entities;

internal class OrderItemEntity
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public OrderEntity Order { get; set; } = new();
    public Guid ProductId { get; set; }
    public ProductEntity Product { get; set; } = new();
}
