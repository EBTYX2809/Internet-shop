using Internet_shop.Domain.Models.ProductData;

namespace Internet_shop.Domain.Models.UserData;

public class ShoppingCart
{   
    public Guid UserId { get; init; }
    private readonly List<Product> _products; 
    public IReadOnlyCollection<Product> Products => _products.AsReadOnly();
    public decimal SummaryPrice { get; private set; }

    public ShoppingCart(Guid userId)
    {
        if (userId == Guid.Empty)
            throw new ArgumentNullException("userId can't be empty.");

        UserId = userId;
        _products = new List<Product>();
        SummaryPrice = 0;
    }

    public void AddProduct(Product product)
    {
        ArgumentNullException.ThrowIfNull(product, nameof(product));
        
        _products.Add(product);
        SummaryPrice += product.Price;
    }

    public void RemoveProduct(Product product)
    {
        ArgumentNullException.ThrowIfNull(product, nameof(product));

        _products.Remove(product);
        SummaryPrice -= product.Price;
    }

    public void Clear()
    {
        _products.Clear();
        SummaryPrice = 0;
    }
}
