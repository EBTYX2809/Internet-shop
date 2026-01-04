using Internet_shop.Domain.Models;
using Internet_shop.Domain.Models.Categorization;
using Internet_shop.Domain.Models.ProductData;
using Internet_shop.Infrastructure.Entities.CategoryEntities;
using Internet_shop.Infrastructure.Entities.ProductEntities;
using Internet_shop.Infrastructure.Entities.UserEntities;

namespace Internet_shop.Infrastructure.Entities;

internal static class DomainMapper
{
    public static ProductInfo EntityToProductInfo(ProductEntity entity)
    {
        return new ProductInfo(entity.Id, entity.Name, entity.Price);
    }
}
