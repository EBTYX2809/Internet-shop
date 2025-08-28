using Internet_shop.Application.Contracts;
using Internet_shop.Domain.Models.Categorization;

namespace Internet_shop.Application.Services;

public class CategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task CreateCategoryAsync(Category category)
    {
        await _categoryRepository.AddAsync(category);
    }

    public async Task UpdateCategoryAsync(Category category)
    {
        await _categoryRepository.UpdateAsync(category);
    }

    public async Task DeleteCategoryAsync(Guid categoryId)
    {
        if (categoryId == Guid.Empty)
            throw new ArgumentNullException("categoryId can't be empty.");

        await _categoryRepository.DeleteAsync(categoryId);
    }

    public async Task<Category> GetCategoryByIdAsync(Guid categoryId)
    {
        if (categoryId == Guid.Empty)
            throw new ArgumentNullException("categoryId can't be empty.");

        var category = await _categoryRepository.GetByIdAsync(categoryId);

        ArgumentNullException.ThrowIfNull(category, nameof(category));

        return category;
    }

    public async Task<IReadOnlyCollection<Category>> GetAllCategoriesByIdAsync()
    {
        return await _categoryRepository.GetAllAsync();
    }
}
