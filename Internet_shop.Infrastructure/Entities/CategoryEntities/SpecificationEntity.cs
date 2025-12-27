namespace Internet_shop.Infrastructure.Entities.CategoryEntities;

internal class SpecificationEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid SubCategoryId { get; set; }
    public SubCategoryEntity SubCategory { get; set; } = new();
    public List<SpecificationValueEntity> SpecificationValues { get; set; } = new();
}