namespace Internet_shop.Application.Contracts.UserContracts;

public interface IShoppingCartRepository
{
    Task AddProductAsync(Guid userId, Guid productId);
    Task RemoveProductAsync(Guid userId, Guid productId);
    Task ClearCartAsync(Guid userId);
}
