using Internet_shop.Application.Contracts;
using Internet_shop.Application.DTOs;
using Internet_shop.Domain.Models;

namespace Internet_shop.Infrastructure.Repositories;

public class SearchProductRepository : ISearchProductRepository
{
    private readonly AppDbContext _dbContext;

    public SearchProductRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PaginatedResultDTO<Product>> GetProductsAsync(ProductQueryDTO productQuery)
    {
        throw new NotImplementedException();
    }
}