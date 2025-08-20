namespace Internet_shop.Domain.Models;

public class Product
{
    public Guid Id { get; init; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public Category Category { get; private set; }
    public List<ProductReview> Reviews { get; private set; }
    public double Rating { get; private set; }

    public Product(string name, string description, decimal price, Category category)
    {
        Id = Guid.NewGuid();

        if (string.IsNullOrWhiteSpace(name) || name.Length > 20)
            throw new ArgumentException("Name can't be null or longer than 20 symbols.");

        if(string.IsNullOrWhiteSpace(description) || description.Length > 100)
            throw new ArgumentException("Description can't be null or longer than 100 symbols.");

        if (price <= 0)
            throw new ArgumentException("Price can't be lower or equal to 0.");

        ArgumentNullException.ThrowIfNull(category, nameof(category));

        Name = name;
        Description = description;
        Price = price;
        Category = category;
        Reviews = new List<ProductReview>();
    }

    public void Rename(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > 20)
            throw new ArgumentException("Name can't be null or longer than 20 symbols.");

        Name = name;
    }

    public void ChangeDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description) || description.Length > 100)
            throw new ArgumentException("Description can't be null or longer than 100 symbols.");

        Description = description;
    }

    public void ChangePrice(decimal price)
    {
        if (price <= 0)
            throw new ArgumentException("Price can't be lower or equal to 0.");

        Price = price;
    }

    public void ChangeCategory(Category category)
    {
        ArgumentNullException.ThrowIfNull(category, nameof(category));

        Category = category;
    }

    public void AddReview(ProductReview review)
    {
        ArgumentNullException.ThrowIfNull(review, nameof(review));

        Reviews.Add(review);
        Rating = Reviews.Average(r => r.Score);
    }
}
