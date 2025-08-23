using Internet_shop.Application.Contracts;
using Internet_shop.Domain.Models;

namespace Internet_shop.Application.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;
    private readonly ProductService _productService;

    public UserService(IUserRepository userRepository, ProductService productService)
    {
        _userRepository = userRepository;
        _productService = productService;
    }

    // CRUDs
    public async Task CreateUserAsync(User user)
    {
        await _userRepository.AddAsync(user); // Idk what to do here else
    }

    public async Task DeleteUserAsync(Guid userId)
    {
        if (userId == Guid.Empty)
            throw new ArgumentNullException("userId can't be empty.");

        await _userRepository.DeleteAsync(userId);
    }

    public async Task<User> GetUserByIdAsync(Guid userId)
    {
        if (userId == Guid.Empty)
            throw new ArgumentNullException("userId can't be empty.");

        var user = await _userRepository.GetByIdAsync(userId);
        
        ArgumentNullException.ThrowIfNull(user, nameof(user));

        return user;
    }

    // Settings
    public async Task SetEmailToUser(string email, Guid userId)
    {
        var user = await GetUserByIdAsync(userId);

        user.SetEmail(email);

        await _userRepository.UpdateAsync(user);
    }

    public async Task SetPhoneToUser(string phone, Guid userId)
    {
        var user = await GetUserByIdAsync(userId);

        user.SetPhone(phone);

        await _userRepository.UpdateAsync(user);
    }

    public async Task SetAddressToUser(UserAddress userAddress, Guid userId)
    {
        var user = await GetUserByIdAsync(userId);

        user.SetAddress(userAddress);

        await _userRepository.UpdateAsync(user);
    }

    // WishList
    public async Task AddProductToUserWishList(Guid productId, Guid userId)
    {
        var product = await _productService.GetProductByIdAsync(productId); 
        var user = await GetUserByIdAsync(userId);

        user.AddToWishList(product);

        await _userRepository.UpdateAsync(user);
    }

    public async Task RemoveProductFromUserWishList(Guid productId, Guid userId)
    {
        var product = await _productService.GetProductByIdAsync(productId);
        var user = await GetUserByIdAsync(userId);

        user.RemoveFromWishList(product);

        await _userRepository.UpdateAsync(user);
    }

    public async Task ClearUserWishList(Guid userId)
    {
        var user = await GetUserByIdAsync(userId);

        user.ClearWishList();

        await _userRepository.UpdateAsync(user);
    }

    // ShoppingCart
    public async Task AddProductToUserShoppingCart(Guid productId, Guid userId)
    {
        var product = await _productService.GetProductByIdAsync(productId);
        var user = await GetUserByIdAsync(userId);

        user.ShoppingCart.AddProduct(product);

        await _userRepository.UpdateAsync(user);
    }

    public async Task RemoveProductFromUserShoppingCart(Guid productId, Guid userId)
    {
        var product = await _productService.GetProductByIdAsync(productId);
        var user = await GetUserByIdAsync(userId);

        user.ShoppingCart.RemoveProduct(product);

        await _userRepository.UpdateAsync(user);
    }

    public async Task ClearUserShoppingCart(Guid userId)
    {
        var user = await GetUserByIdAsync(userId);

        user.ShoppingCart.Clear();

        await _userRepository.UpdateAsync(user);
    }

    // OrdersHistory
    public async Task AddOrderToUserOrdersHistory(Order order, Guid userId)
    {
        var user = await GetUserByIdAsync(userId);

        user.AddOrder(order);

        await _userRepository.UpdateAsync(user);
    }

    public async Task SetDeliveredDateForOrder(Guid orderId, Guid userId, DateTime date)
    {
        var user = await GetUserByIdAsync(userId);
        var order = user.OrdersHistory.FirstOrDefault(o => o.Id == orderId);

        if (order == null)
            throw new ArgumentNullException("Order with this id isn't exist.");

        order.SetDeliveredDate(date);

        await _userRepository.UpdateAsync(user);
    }
}
