namespace Internet_shop.Domain.Models;

public class User
{
    public Guid Id { get; init; }
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public UserAddress Address { get; private set; }
    public ShoppingCart ShoppingCart { get; private set; }
    private readonly List<Product> _wishList;
    public IReadOnlyCollection<Product> WishList => _wishList.AsReadOnly();

    private readonly List<Order> _ordersHistory;
    public IReadOnlyCollection<Order> OrdersHistory => _ordersHistory.AsReadOnly();

    public User(string emailOrPhone)
    {
        Id = Guid.NewGuid();
        InitializeEmailOrPhone(emailOrPhone);
        ShoppingCart = new ShoppingCart(Id);
        _wishList = new List<Product>();
        _ordersHistory = new List<Order>();
    }

    public User(Guid id, string emailOrPhone)
    {
        Id = id;
        InitializeEmailOrPhone(emailOrPhone);
        ShoppingCart = new ShoppingCart(Id);
        _wishList = new List<Product>();
        _ordersHistory = new List<Order>();
    }

    private void InitializeEmailOrPhone(string emailOrPhone)
    {
        try
        {
            SetEmail(emailOrPhone);
            SetPhone(emailOrPhone);
        }
        catch (ArgumentException ex) { }

        if (string.IsNullOrWhiteSpace(Email) && string.IsNullOrWhiteSpace(Phone))
            throw new ArgumentException("Either a valid email or phone number must be provided.");
    }

    public void SetEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email can't be empty.");

        if (!email.Contains("@") || !email.Contains("."))
            throw new ArgumentException("Email format is invalid.");

        Email = email;
    }

    public void SetPhone(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
            throw new ArgumentException("Phone number cannot be empty.");

        // Simple pattern: optional +, digits only, length 7–15
        var regex = @"^\+?[0-9]{7,15}$";

        if (!System.Text.RegularExpressions.Regex.IsMatch(phone, regex))
            throw new ArgumentException("Phone number format is invalid.");

        Phone = phone;
    }

    public void SetAddress(UserAddress userAddress)
    {
        ArgumentNullException.ThrowIfNull(userAddress, nameof(userAddress));

        Address = userAddress;
    }

    public void AddToWishList(Product product)
    {
        ArgumentNullException.ThrowIfNull(product, nameof(product));

        if (_wishList.Contains(product))
            throw new InvalidOperationException("Product already in wishlist.");

        _wishList.Add(product);
    }

    public void RemoveFromWishList(Product product)
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

    public void AddOrder(Order order)
    {
        ArgumentNullException.ThrowIfNull(order, nameof(order));

        _ordersHistory.Add(order);
    }
}
