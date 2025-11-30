using Internet_shop.Domain.Models.Categorization;

namespace Internet_shop.Domain.Models;

public class Product
{
    public Guid Id { get; init; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public CategoryInfo Category { get; private set; }
    public CategoryInfo SubCategory { get; private set; }
    private Dictionary<string, string> _specificationList;
    public IReadOnlyDictionary<string, string> SpecificationList => _specificationList.AsReadOnly();
    private List<ProductReview> _reviews;
    public IReadOnlyCollection<ProductReview> Reviews => _reviews.AsReadOnly();
    public double Rating { get; private set; }

    public Product(string name, string description, decimal price,
        CategoryInfo category, CategoryInfo subCategory, Dictionary<string, string> specificationList)
    {
        Id = Guid.NewGuid();

        if (string.IsNullOrWhiteSpace(name) || name.Length > 20)
            throw new ArgumentException("Name can't be null or longer than 20 symbols.");

        if (string.IsNullOrWhiteSpace(description) || description.Length > 100)
            throw new ArgumentException("Description can't be null or longer than 100 symbols.");

        if (price <= 0)
            throw new ArgumentException("Price can't be lower or equal to 0.");

        ArgumentNullException.ThrowIfNull(category, nameof(category));

        Name = name;
        Description = description;
        Price = price;
        Category = category;
        _specificationList = specificationList;
        SubCategory = subCategory;

        _reviews = new List<ProductReview>();
    }

    public Product(Guid id, string name, string description, decimal price,
        CategoryInfo category, CategoryInfo subCategory, Dictionary<string, string> specificationList)
    {
        Id = id;

        if (string.IsNullOrWhiteSpace(name) || name.Length > 20)
            throw new ArgumentException("Name can't be null or longer than 20 symbols.");

        if (string.IsNullOrWhiteSpace(description) || description.Length > 100)
            throw new ArgumentException("Description can't be null or longer than 100 symbols.");

        if (price <= 0)
            throw new ArgumentException("Price can't be lower or equal to 0.");

        ArgumentNullException.ThrowIfNull(category, nameof(category));

        Name = name;
        Description = description;
        Price = price;
        Category = category;
        _specificationList = specificationList;
        SubCategory = subCategory;

        _reviews = new List<ProductReview>();
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

    public void ChangeCategory(CategoryInfo categoryInfo)
    {
        ArgumentNullException.ThrowIfNull(categoryInfo, nameof(categoryInfo));

        Category = categoryInfo;
    }

    public void ChangeSubCategory(CategoryInfo categoryInfo)
    {
        ArgumentNullException.ThrowIfNull(categoryInfo, nameof(categoryInfo));

        SubCategory = categoryInfo;
    }

    public void ChangeSpecificationList(Dictionary<string, string> specificationList)
    {
        ArgumentNullException.ThrowIfNull(specificationList, nameof(specificationList));

        _specificationList = specificationList;
    }

    public void AddReview(ProductReview review)
    {
        ArgumentNullException.ThrowIfNull(review, nameof(review));

        if (_reviews.Any(r => r.ProductId == review.ProductId) && _reviews.Any(r => r.UserId == review.UserId))
            throw new InvalidOperationException("One user could have only one review to one product.");

        _reviews.Add(review);
        Rating = _reviews.Average(r => r.Score);
    }
}
