namespace Internet_shop.Domain.Models.Categorization;

public class SubCategory
{
    public CategoryInfo CategoryInfo { get; init; }
    public Guid ParentCategoryId { get; init; }
    private Dictionary<string, string[]> _specifications;
    public IReadOnlyDictionary<string, string[]> Specifications => _specifications.AsReadOnly();
    public SubCategory(CategoryInfo categoryInfo, Guid parentCategoryId, Dictionary<string, string[]> specifications)
    {
        CategoryInfo = categoryInfo;
        ParentCategoryId = parentCategoryId;
        _specifications = specifications;
    }
}
