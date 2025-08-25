using Internet_shop.Application.Enums;

namespace Internet_shop.Application.DTOs;

public class ProductQueryDTO
{
    // pagination
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;

    // sorting
    public SortingParameter SortBy { get; set; } 
    public SortingOrder OrderBy { get; set; }

    // filtering
    //public ProductFilter Filter { get; set; } // create product filter infrastructure
}
