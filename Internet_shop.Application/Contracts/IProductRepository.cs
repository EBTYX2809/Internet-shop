using Internet_shop.Domain.Models;

namespace Internet_shop.Application.Contracts;

public interface IProductRepository
{
    Task CreateProductAsync(Product product);
    Task UpdateProductAsync(Product product);
    Task DeleteProductAsync(Guid productId);
    Task<Product?> GetProductByIdAsync(Guid productId);
    Task<IReadOnlyCollection<Product>> GetAllProductsAsync(); // Implement pagination and sorting here
}
