namespace Internet_shop.Domain.Models.UserData;

public class User
{
    public Customer CustomerData { get; private set; }
    public string Email { get; private set; }
    public PasswordData Password { get; private set; }
    public string Phone { get; private set; }
    public UserAddress Address { get; private set; }    
    private readonly List<Order> _ordersHistory;
    public IReadOnlyCollection<Order> OrdersHistory => _ordersHistory.AsReadOnly();
    public User()
    {
        CustomerData = new Customer();
        _ordersHistory = new List<Order>();
    }

    public User(Guid id)
    {
        CustomerData = new Customer(id);
        _ordersHistory = new List<Order>();
    }

    public void SetEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email can't be empty.");

        if (!email.Contains("@") || !email.Contains("."))
            throw new ArgumentException("Email format is invalid.");

        Email = email;
    }

    public void SetPasswordData(string passwordHash, string salt)
    {
        Password = new PasswordData(passwordHash, salt);
    }

    public void AddPassword(string password)
    {
        Password = new PasswordData(password);
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

    public void AddOrder(Order order)
    {
        ArgumentNullException.ThrowIfNull(order, nameof(order));

        _ordersHistory.Add(order);
    }
}
