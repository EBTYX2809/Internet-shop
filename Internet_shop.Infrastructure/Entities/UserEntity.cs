namespace Internet_shop.Infrastructure.Entities;

internal class UserEntity
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string AddressCountry { get; set; } = string.Empty;
    public string AddressCity { get; set; } = string.Empty;
    public string AddressStreet { get; set; } = string.Empty;
    public List<ProductEntity> WishList { get; set; } = new();
    public List<OrderEntity> OrdersHistory { get; set; } = new();
    public List<ShoppingCartItemEntity> ShoppingCart { get; set; } = new();
}
