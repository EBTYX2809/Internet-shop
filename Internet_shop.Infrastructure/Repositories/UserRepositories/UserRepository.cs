using Internet_shop.Application.Contracts.UserContracts;
using Internet_shop.Domain.Models.ProductData;
using Internet_shop.Domain.Models.UserData;
using Internet_shop.Infrastructure.Entities;
using Internet_shop.Infrastructure.Entities.ProductEntities;
using Internet_shop.Infrastructure.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;

namespace Internet_shop.Infrastructure.Repositories.UserRepositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _dbContext;
    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateAsync(Guid guestId)
    {
        await UserCheckAsync(guestId);

        var userEntity = new UserEntity { Id = guestId };

        await _dbContext.Users.AddAsync(userEntity);
    }

    public async Task DeleteAsync(Guid userId)
    {
        var userEntity = await GetUserEnityAsync(userId);

        _dbContext.Users.Remove(userEntity);
    }

    public async Task<Customer?> GetCustomerByIdAsync(Guid customerId)
    {
        var userEntity = await _dbContext.Users
            .Include(u => u.WishList)
            .Include(u => u.ShoppingCart)
                .ThenInclude(sci => sci.Product)
            .AsSplitQuery()
            .FirstOrDefaultAsync(u => u.Id == customerId);

        var customer = new Customer(userEntity.Id);

        // Change to map productEntity to productInfo
        customer.WishList = userEntity.WishList.Select(p => DomainMapper.EntityToProductInfo(p.Product)).ToList();

        var shoppingCart = userEntity.ShoppingCart.Select(s => DomainMapper.EntityToProductInfo(s.Product)).ToList();

        customer.ShoppingCart = new ShoppingCart(userEntity.Id, shoppingCart);

        customer.ShoppingCart.SummaryPrice = shoppingCart.Sum(p => p.Price);

        return customer;
    }

    public async Task<User?> GetUserProfileByIdAsync(Guid userId)
    {
        var customer = await GetCustomerByIdAsync(userId);

        var userEntity = await _dbContext.Users
            .Include(u => u.OrdersHistory)
                .ThenInclude(oh => oh.Products)
                    .ThenInclude(p => p.Product)            
            .AsSplitQuery()
            .FirstOrDefaultAsync(u => u.Id == userId);

        var user = new User(userEntity.Id);

        user.CustomerData = customer;

        user.Email = userEntity.Email;
        user.Phone = userEntity.Phone;
        user.Address = new UserAddress(userEntity.AddressCountry, userEntity.AddressCity, userEntity.AddressStreet);

        user.Password = new PasswordData(userEntity.PasswordHash, userEntity.Salt);

        // Add order delivered date to original constructor 
        user.OrdersHistory = userEntity.OrdersHistory.Select(oh => new Order(oh.Id, customer.Id, oh.CreatedDate, oh.Products.Select(p => DomainMapper.EntityToProductInfo(p.Product)).ToList())).ToList();

        return user;
    }

    internal async Task<UserEntity> GetUserEnityAsync(Guid id)
    {
        var userEntity = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

        if (userEntity == null) throw new InvalidOperationException("Error, this user does not exist.");

        return userEntity;
    }

    internal async Task UserCheckAsync(Guid id)
    {
        var userCheck = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (userCheck != null) throw new InvalidOperationException("Error, this user already exist.");
    }
}
