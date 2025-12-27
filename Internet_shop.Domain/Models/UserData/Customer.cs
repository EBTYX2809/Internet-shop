namespace Internet_shop.Domain.Models.UserData;

public class Customer
{
    public Guid Id { get; init; }
    public bool IsGuest { get; set; } // private set
    public ShoppingCart ShoppingCart { get; private set; }
    private readonly List<ProductInfo> _wishList;
    public IReadOnlyCollection<ProductInfo> WishList => _wishList.AsReadOnly();
    public Customer(Guid id)
    {
        Id = id;
        ShoppingCart = new ShoppingCart(Id);
        _wishList = new List<ProductInfo>();
    }

    public Customer()
    {
        Id = Guid.NewGuid();
        ShoppingCart = new ShoppingCart(Id);
        _wishList = new List<ProductInfo>();
    }

/*    public void GuestAuthenticated()
    {
        IsGuest = false;
    }*/

    public void AddToWishList(ProductInfo product)
    {
        ArgumentNullException.ThrowIfNull(product, nameof(product));

        if (_wishList.Contains(product))
            throw new InvalidOperationException("Product already in wishlist.");

        _wishList.Add(product);
    }

    public void RemoveFromWishList(ProductInfo product)
    {
        ArgumentNullException.ThrowIfNull(product, nameof(product));

        if (!_wishList.Contains(product))
            throw new InvalidOperationException("Product not found in wishlist.");

        _wishList.Remove(product);
    }

    public void ClearWishList()
    {
        _wishList.Clear();
    }
}
