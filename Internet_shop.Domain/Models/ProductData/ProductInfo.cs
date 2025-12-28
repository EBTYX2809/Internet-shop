namespace Internet_shop.Domain.Models.ProductData;

public class ProductInfo
{
    public Guid Id { get; init; }    
    public string Name { get; private set; }
    public decimal Price { get; private set; }

    public ProductInfo(Guid id, string name, decimal price)
    {
        Id = id;

        if (string.IsNullOrWhiteSpace(name) || name.Length > 20)
            throw new ArgumentException("Name can't be null or longer than 20 symbols.");

        if (price <= 0)
            throw new ArgumentException("Price can't be lower or equal to 0.");

        Name = name;
        Price = price;
    }

    public ProductInfo(string name, decimal price)
    {
        Id = Guid.NewGuid();

        if (string.IsNullOrWhiteSpace(name) || name.Length > 20)
            throw new ArgumentException("Name can't be null or longer than 20 symbols.");

        if (price <= 0)
            throw new ArgumentException("Price can't be lower or equal to 0.");

        Name = name;
        Price = price;
    }

    public void Rename(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > 20)
            throw new ArgumentException("Name can't be null or longer than 20 symbols.");

        Name = name;
    }

    public void ChangePrice(decimal price)
    {
        if (price <= 0)
            throw new ArgumentException("Price can't be lower or equal to 0.");

        Price = price;
    }
}
