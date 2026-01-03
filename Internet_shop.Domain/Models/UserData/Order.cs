using Internet_shop.Domain.Models.ProductData;

namespace Internet_shop.Domain.Models.UserData;

public class Order
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public DateTime CreatedDate { get; init; }
    public DateTime? DeliveredDate { get; set; }
    public List<ProductInfo> Products { get; init; }
    public decimal SummaryPrice { get; init; }

    public Order(Guid userId, List<ProductInfo> products)
    {
        Id = Guid.NewGuid();      
        UserId = userId;
        CreatedDate = DateTime.UtcNow;        
        Products = products;
        SummaryPrice = products.Sum(p => p.Price);
    }

    public Order(Guid id, Guid userId, DateTime createdDatae, List<ProductInfo> products)
    {
        Id = id;
        UserId = userId;
        CreatedDate = createdDatae;
        Products = products;
        SummaryPrice = products.Sum(p => p.Price);
    }
}
