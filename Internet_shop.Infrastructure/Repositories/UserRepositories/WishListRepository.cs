using Internet_shop.Application.Contracts.UserContracts;
using Internet_shop.Infrastructure.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;

namespace Internet_shop.Infrastructure.Repositories.UserRepositories;

public class WishListRepository : IWishListRepository
{
    private readonly AppDbContext _appDbContext;

    public WishListRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task AddProductAsync(Guid userId, Guid productId)
    {
        var newItem = new WishListItemEntity()
        {
            Id = Guid.NewGuid(), // Honestly idk why Guid is needed here
            UserId = userId,
            ProductId = productId
        };

        await _appDbContext.WishLists.AddAsync(newItem);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task ClearWishListAsync(Guid userId)
    {
        var shoppingCartItems = _appDbContext.WishLists.Where(sc => sc.UserId == userId);

        _appDbContext.WishLists.RemoveRange(shoppingCartItems);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task RemoveProductAsync(Guid userId, Guid productId)
    {
        var shoppingCartItem = await _appDbContext.WishLists.FirstOrDefaultAsync(sc => sc.UserId == userId && sc.ProductId == productId);

        _appDbContext.WishLists.Remove(shoppingCartItem);
        await _appDbContext.SaveChangesAsync();
    }
}
