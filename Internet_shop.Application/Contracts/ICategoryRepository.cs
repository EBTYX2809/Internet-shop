using Internet_shop.Domain.Models;

namespace Internet_shop.Application.Contracts;

public interface ICategoryRepository
{
    Task CreateCategoryAsync(Category category);
    Task UpdateCategoryAsync(Category category);
    Task DeleteCategoryAsync(Guid categoryId);
    Task<Category?> GetCategoryByIdAsync(Guid categoryId);
    Task<IReadOnlyCollection<Category>> GetAllCategoriesAsync();
}
