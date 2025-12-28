using Internet_shop.Domain.Models.ProductData;

namespace Internet_shop.Domain.Models.UserData;

public class Order
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public DateTime CreatedDate { get; init; }
    public DateTime? DeliveredDate { get; private set; }
    public List<Product> Products { get; init; }
    public decimal SummaryPrice { get; init; }

    public Order(Guid userId, List<Product> products)
    {
        Id = Guid.NewGuid();

        if(userId == Guid.Empty)
            throw new ArgumentNullException("userId can't be empty.");

        ArgumentNullException.ThrowIfNull(products, nameof(products));        

        UserId = userId;
        CreatedDate = DateTime.UtcNow;        
        Products = products;
        SummaryPrice = products.Sum(p => p.Price);
    }

    public Order(Guid id, Guid userId, DateTime createdDatae, List<Product> products)
    {
        Id = id;

        if (userId == Guid.Empty)
            throw new ArgumentNullException("userId can't be empty.");

        ArgumentNullException.ThrowIfNull(products, nameof(products));

        UserId = userId;
        CreatedDate = createdDatae;
        Products = products;
        SummaryPrice = products.Sum(p => p.Price);
    }

    public void SetDeliveredDate(DateTime deliveredDate)
    {
        if(DeliveredDate <= DateTime.UtcNow || DeliveredDate >= DateTime.UtcNow.AddMonths(2))
            throw new ArgumentNullException("Delivered date can't be in past or so far in future.");

        DeliveredDate = deliveredDate;
    }
}
