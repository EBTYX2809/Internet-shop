using Internet_shop.Application.Contracts.UserContracts;
using Internet_shop.Infrastructure.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;

namespace Internet_shop.Infrastructure.Repositories.UserRepositories;

public class ShoppingCartRepository : IShoppingCartRepository
{
    private readonly AppDbContext _appDbContext;
    public ShoppingCartRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task AddProductAsync(Guid userId, Guid productId)
    {
        var newItem = new ShoppingCartItemEntity()
        {
            Id = Guid.NewGuid(), // Honestly idk why Guid is needed here
            UserId = userId,
            ProductId = productId
        };

        await _appDbContext.ShoppingCarts.AddAsync(newItem);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task ClearCartAsync(Guid userId)
    {
        var shoppingCartItems = _appDbContext.ShoppingCarts.Where(sc => sc.UserId == userId);

        _appDbContext.ShoppingCarts.RemoveRange(shoppingCartItems);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task RemoveProductAsync(Guid userId, Guid productId)
    {
        var shoppingCartItem = await _appDbContext.ShoppingCarts.FirstOrDefaultAsync(sc => sc.UserId == userId && sc.ProductId == productId);

        _appDbContext.ShoppingCarts.Remove(shoppingCartItem);
        await _appDbContext.SaveChangesAsync();
    }
}
