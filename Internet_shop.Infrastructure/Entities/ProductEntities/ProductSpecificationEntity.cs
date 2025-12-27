using Internet_shop.Infrastructure.Entities.CategoryEntities;

namespace Internet_shop.Infrastructure.Entities.ProductEntities;

internal class ProductSpecificationEntity
{
    public Guid ProductId { get; set; }
    public ProductEntity Product { get; set; } = new();
    public Guid SpecificationId { get; set; }
    public SpecificationEntity Specification { get; set; } = new();
    public Guid SpecificationValueId { get; set; }
    public SpecificationValueEntity SpecificationValue { get; set; } = new();
}
