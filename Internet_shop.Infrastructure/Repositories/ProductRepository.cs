using Internet_shop.Application.Contracts;
using Internet_shop.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Internet_shop.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _dbContext;

    public ProductRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(Guid productId)
    {
        var product = await _dbContext.Products.FirstOrDefaultAsync(u => u.Id == productId);

        _dbContext.Products.Remove(product);
    }

    public async Task<Product?> GetByIdAsync(Guid productId)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Product product)
    {
        throw new NotImplementedException();
    }
}