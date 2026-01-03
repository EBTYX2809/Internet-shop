namespace Internet_shop.Domain.Models.UserData;

public class User
{
    public Customer CustomerData { get; set; }
    public string Email { get; set; }
    public PasswordData Password { get; set; }
    public string Phone { get; set; }
    public UserAddress Address { get; set; }    
    public List<Order> OrdersHistory { get; set; }
    public User()
    {
        CustomerData = new Customer();
        OrdersHistory = new List<Order>();
    }

    public User(Guid id)
    {
        CustomerData = new Customer(id);
        OrdersHistory = new List<Order>();
    }
}
