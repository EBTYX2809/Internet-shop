using Internet_shop.Infrastructure.Entities.UserEntities;

namespace Internet_shop.Infrastructure.Entities.ProductEntities;

internal class ProductReviewEntity
{
    public Guid ProductId { get; set; }
    public ProductEntity Product { get; set; } = new();
    public Guid UserId { get; set; }
    public UserEntity User { get; set; } = new();
    public short Score { get; set; }
    public string Review { get; set; } = string.Empty;
}
