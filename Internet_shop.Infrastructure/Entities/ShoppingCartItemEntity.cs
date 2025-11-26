namespace Internet_shop.Infrastructure.Entities;

internal class ShoppingCartItemEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public UserEntity User { get; set; } = new();
    public Guid ProductId { get; set; }
    public ProductEntity Product { get; set; } = new();
}
