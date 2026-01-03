namespace Internet_shop.Domain.Models.UserData;

public class UserAddress
{
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }

    public UserAddress(string country, string city, string street)
    {
        Country = country;
        City = city;
        Street = street;
    }
}
