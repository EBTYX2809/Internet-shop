using Internet_shop.Infrastructure.Entities.ProductEntities;

namespace Internet_shop.Infrastructure.Entities.UserEntities;

internal class UserEntity
{
    public Guid Id { get; set; }
    public bool IsGuest { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Salt { get; set; } = string.Empty;
    public string AddressCountry { get; set; } = string.Empty;
    public string AddressCity { get; set; } = string.Empty;
    public string AddressStreet { get; set; } = string.Empty;
    public List<ProductEntity> WishList { get; set; } = new();
    public List<OrderEntity> OrdersHistory { get; set; } = new();
    public List<ShoppingCartItemEntity> ShoppingCart { get; set; } = new();
}
