using Internet_shop.Application.Contracts;
using Internet_shop.Domain.Models.Categorization;

namespace Internet_shop.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _dbContext;

    public CategoryRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Category category)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(Guid categoryId)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyCollection<Category>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Category?> GetByIdAsync(Guid categoryId)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Category category)
    {
        throw new NotImplementedException();
    }
}