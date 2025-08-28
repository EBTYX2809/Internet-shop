namespace Internet_shop.Domain.Models.Categorization;

public class Category
{
    public CategoryInfo CategoryInfo { get; init; }
    private List<SubCategory>? _subCategories;
    public IReadOnlyCollection<SubCategory>? SubCategories => _subCategories?.AsReadOnly();
    public Category(CategoryInfo categoryInfo, List<SubCategory>? subCategories = null)
    {
        CategoryInfo = categoryInfo;
        _subCategories = subCategories;
    }
}
