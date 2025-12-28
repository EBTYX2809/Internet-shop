using Internet_shop.Domain.Models.Categorization;

namespace Internet_shop.Domain.Models.ProductData;

public class Product
{ 
    public ProductInfo ProductInfo { get; private set; }
    public string Description { get; private set; }
    public CategoryInfo Category { get; private set; }
    public CategoryInfo SubCategory { get; private set; }
    private Dictionary<string, string> _specificationList;
    public IReadOnlyDictionary<string, string> SpecificationList => _specificationList.AsReadOnly();
    private List<ProductReview> _reviews;
    public IReadOnlyCollection<ProductReview> Reviews => _reviews.AsReadOnly();
    public double Rating { get; private set; }

    public Product(ProductInfo productInfo, string description, CategoryInfo category, 
        CategoryInfo subCategory, Dictionary<string, string> specificationList)
    {
        ProductInfo = productInfo;

        if (string.IsNullOrWhiteSpace(description) || description.Length > 100)
            throw new ArgumentException("Description can't be null or longer than 100 symbols.");

        ArgumentNullException.ThrowIfNull(category, nameof(category));

        Description = description;
        Category = category;
        _specificationList = specificationList;
        SubCategory = subCategory;

        _reviews = new List<ProductReview>();
    }    

    public void ChangeDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description) || description.Length > 100)
            throw new ArgumentException("Description can't be null or longer than 100 symbols.");

        Description = description;
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
