using Internet_shop.Application.DTOs;
using Internet_shop.Domain.Models.ProductData;

namespace Internet_shop.Application.Contracts;

public interface ISearchProductRepository
{
    public Task<PaginatedResultDTO<Product>> GetProductsAsync(ProductQueryDTO productQuery);    
}
