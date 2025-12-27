namespace Internet_shop.Infrastructure.Entities.CategoryEntities;

internal class CategoryEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<SubCategoryEntity> SubCategories { get; set; } = new();
}
