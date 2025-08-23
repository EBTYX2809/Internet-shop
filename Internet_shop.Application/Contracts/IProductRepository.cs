using Internet_shop.Domain.Models;

namespace Internet_shop.Application.Contracts;

public interface IProductRepository
{
    Task CreateAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Guid productId);
    Task<Product?> GetByIdAsync(Guid productId);
    Task<IReadOnlyCollection<Product>> GetListAsync(); // Implement pagination and sorting here
}
