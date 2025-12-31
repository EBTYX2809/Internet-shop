namespace Internet_shop.Application.Contracts.UserContracts;

public interface IWishListRepository
{
    Task AddProductAsync(Guid userId, Guid productId);
    Task RemoveProductAsync(Guid userId, Guid productId);
    Task ClearWishListAsync(Guid userId);
}
