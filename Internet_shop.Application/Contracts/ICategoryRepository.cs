using Internet_shop.Domain.Models;

namespace Internet_shop.Application.Contracts;

public interface ICategoryRepository
{
    Task AddAsync(Category category);
    Task UpdateAsync(Category category);
    Task DeleteAsync(Guid categoryId);
    Task<Category?> GetByIdAsync(Guid categoryId);
    Task<IReadOnlyCollection<Category>> GetListAsync();
}
