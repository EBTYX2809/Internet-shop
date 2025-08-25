using Internet_shop.Domain.Models;

namespace Internet_shop.Application.Contracts;

public interface IProductRepository
{
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Guid productId);
    Task<Product?> GetByIdAsync(Guid productId);    
}
