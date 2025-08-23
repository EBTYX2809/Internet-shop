using Internet_shop.Application.Contracts;
using Internet_shop.Domain.Models;

namespace Internet_shop.Application.Services;

public class ProductService
{
    private readonly IProductRepository _productRepository;
    private readonly CategoryService _categoryService;

    public ProductService(IProductRepository productRepository, CategoryService categoryService)
    {
        _productRepository = productRepository;
        _categoryService = categoryService;
    }

    // CRUDs
    public async Task CreateProductAsync(Product product)
    {
        await _productRepository.AddAsync(product);
    }

    public async Task DeleteProductAsync(Guid productId)
    {
        if (productId == Guid.Empty)
            throw new ArgumentNullException("productId can't be empty.");

        await _productRepository.DeleteAsync(productId);
    }

    public async Task<Product> GetProductByIdAsync(Guid productId)
    {
        if (productId == Guid.Empty)
            throw new ArgumentNullException("productId can't be empty.");

        var product = await _productRepository.GetByIdAsync(productId);

        ArgumentNullException.ThrowIfNull(product, nameof(product));

        return product;
    }

    // To do pagination here

    // Settings
    public async Task RenameProductAsync(Guid productId, string newName)
    {
        var product = await GetProductByIdAsync(productId);

        product.Rename(newName);

        await _productRepository.UpdateAsync(product);
    }

    public async Task ChangeDescriptionInProductAsync(Guid productId, string newDescription)
    {
        var product = await GetProductByIdAsync(productId);

        product.ChangeDescription(newDescription);

        await _productRepository.UpdateAsync(product);
    }

    public async Task ChangePriceForProductAsync(Guid productId, decimal newPrice)
    {
        var product = await GetProductByIdAsync(productId);

        product.ChangePrice(newPrice);

        await _productRepository.UpdateAsync(product);
    }

    public async Task ChangeCategoryForProductAsync(Guid productId, Guid categoryId)
    {
        var product = await GetProductByIdAsync(productId);
        var category = await _categoryService.GetCategoryByIdAsync(categoryId);

        product.ChangeCategory(category);

        await _productRepository.UpdateAsync(product);
    }

    // ProductReview
    public async Task AddReviewToProductAsync(Guid productId, ProductReview review)
    {
        var product = await GetProductByIdAsync(productId);

        product.AddReview(review);

        await _productRepository.UpdateAsync(product);
    }
}
