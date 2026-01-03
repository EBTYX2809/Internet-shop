using Internet_shop.Domain.Models.ProductData;

namespace Internet_shop.Domain.Models.UserData;

public class Customer
{
    public Guid Id { get; init; }
    public bool IsGuest { get; set; } // private set
    public ShoppingCart ShoppingCart { get; set; }
    public List<ProductInfo> WishList { get; set; }
    public Customer(Guid id)
    {
        Id = id;
        ShoppingCart = new ShoppingCart(Id);
        WishList = new List<ProductInfo>();
    }

    public Customer()
    {
        Id = Guid.NewGuid();
        ShoppingCart = new ShoppingCart(Id);
        WishList = new List<ProductInfo>();
    }

/*    public void GuestAuthenticated()
    {
        IsGuest = false;
    }*/
}
