namespace Internet_shop.Domain.Models;

public class User
{
    public Guid Id { get; init; }
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public UserAddress Address { get; private set; }
    public ShoppingCart ShoppingCart { get; private set; }
    public List<Product> WishList { get; private set; }
    public List<Order> OrdersHistory { get; private set; }

    public User()
    {
        Id = Guid.NewGuid();

        ShoppingCart = new ShoppingCart(Id);
        WishList = new List<Product>();
        OrdersHistory = new List<Order>();
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
}
