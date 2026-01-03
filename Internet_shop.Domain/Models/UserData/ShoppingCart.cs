using Internet_shop.Domain.Models.ProductData;

namespace Internet_shop.Domain.Models.UserData;

public class ShoppingCart
{   
    public Guid UserId { get; init; }
    public List<ProductInfo> Products { get; set; }
    public decimal SummaryPrice { get; set; } // private set under add/remove methods

    public ShoppingCart(Guid userId)
    {
        UserId = userId;
        Products = new List<ProductInfo>();
        SummaryPrice = 0;
    }

    public ShoppingCart(Guid userId, List<ProductInfo> products)
    {
        UserId = userId;
        Products = products;
        SummaryPrice = 0;
    }
}
