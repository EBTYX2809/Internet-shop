namespace Internet_shop.Infrastructure.Entities;

internal class OrderEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public UserEntity User { get; set; } = new();
    public DateTime CreatedDate { get; set; }
    public DateTime DeliveredDate { get; set; }
    public List<OrderItemEntity> Products { get; set; } = new();
    public decimal SummaryPrice { get; set; }
}
