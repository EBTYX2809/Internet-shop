using System.Reflection.Emit;

namespace Internet_shop.Domain.Models;

public class UserAddress
{
    public string Country { get; private set; }
    public string City { get; private set; }
    public string Street { get; private set; }

    public UserAddress(string country, string city, string street)
    {
        if (string.IsNullOrWhiteSpace(country))
            throw new ArgumentException("Country can't be empty.");

        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("City can't be empty.");

        if (string.IsNullOrWhiteSpace(street))
            throw new ArgumentException("Street can't be empty.");

        Country = country;
        City = city;
        Street = street;
    }
}
