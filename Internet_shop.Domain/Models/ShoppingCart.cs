namespace Internet_shop.Domain.Models;

public class ShoppingCart
{   
    public Guid UserId { get; init; }
    public List<Product> Products { get; private set; }
    public decimal SummaryPrice { get; private set; }

    public ShoppingCart(Guid userId)
    {
        if (userId == Guid.Empty)
            throw new ArgumentNullException("userId can't be empty.");

        UserId = userId;
        Products = new List<Product>();
        SummaryPrice = 0;
    }

    public void AddProduct(Product product)
    {
        ArgumentNullException.ThrowIfNull(product, nameof(product));
        
        Products.Add(product);
        SummaryPrice += product.Price;
    }

    public void RemoveProduct(Product product)
    {
        ArgumentNullException.ThrowIfNull(product, nameof(product));

        Products.Remove(product);
        SummaryPrice -= product.Price;
    }

    public void Clear()
    {
        Products.Clear();
        SummaryPrice = 0;
    }
}
