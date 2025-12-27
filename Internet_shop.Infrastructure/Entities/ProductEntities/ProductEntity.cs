using Internet_shop.Infrastructure.Entities.CategoryEntities;

namespace Internet_shop.Infrastructure.Entities.ProductEntities;

internal class ProductEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
    public CategoryEntity Category { get; set; } = new();
    public Guid SubCategoryId { get; set; }
    public SubCategoryEntity SubCategory { get; set; } = new();
    public List<ProductSpecificationEntity> SpecificationList { get; set; } = new();
    public List<ProductReviewEntity> Reviews { get; set; } = new();
    public float Rating { get; set; }
}
