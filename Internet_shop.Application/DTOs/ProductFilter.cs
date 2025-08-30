using System.Linq.Expressions;
using Internet_shop.Domain.Models;
using Internet_shop.Domain.Models.Categorization;

namespace Internet_shop.Application.DTOs;

public class ProductFilter
{
    public Dictionary<string, string[]>? SpecificationFilters { get; set; }
    public Guid? CategoryId { get; set; }
    public Guid? SubCategoryId { get; set; }
    public decimal? MinPrice { get; set; } = 0;
    public decimal? MaxPrice { get; set; } = decimal.MaxValue;

    public Expression<Func<Product, bool>> ToExpression()
    {
        return product => // Maybe refactor it to more readable view. 
            (!CategoryId.HasValue || product.Category.Id == CategoryId.Value) &&
            (!SubCategoryId.HasValue || product.SubCategory.Id == SubCategoryId.Value) &&
            (!MinPrice.HasValue || product.Price >= MinPrice.Value) &&
            (!MaxPrice.HasValue || product.Price <= MaxPrice.Value) &&
            // Currently this checks every filter from SpecificationFilters on marching with product SpecificationList parameters
            (SpecificationFilters == null ||
                SpecificationFilters.All(filter =>
                    product.SpecificationList.Any(specsParameter =>
                        specsParameter.Key == filter.Key && filter.Value.Contains(specsParameter.Value))));
    }
}