namespace Internet_shop.Infrastructure.Entities.CategoryEntities;

internal class SubCategoryEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid CategoryId { get; set; }
    public CategoryEntity Category { get; set; } = new();
    public List<SpecificationEntity> Specifications { get; set; } = new();
}