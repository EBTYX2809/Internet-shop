using Internet_shop.Application.Contracts.UserContracts;
using Internet_shop.Domain.Models.UserData;
using Microsoft.EntityFrameworkCore;

namespace Internet_shop.Infrastructure.Repositories.UserRepositories;

public class UserUpdateRepository : IUserUpdateRepository
{
    private readonly AppDbContext _appDbContext;

    public UserUpdateRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task UpdateAddressAsync(Guid userId, UserAddress address)
    {
        var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

        user.AddressCountry = address.Country;
        user.AddressCity = address.City;    
        user.AddressStreet = address.Street;

        await _appDbContext.SaveChangesAsync();
    }

    public async Task UpdateEmailAsync(Guid userId, string email)
    {
        var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

        user.Email = email;

        await _appDbContext.SaveChangesAsync();
    }

    public async Task UpdateGuestToUserAsync(Guid userId)
    {
        var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

        user.IsGuest = false;

        await _appDbContext.SaveChangesAsync();
    }

    public async Task UpdatePasswordAsync(Guid userId, string passwordHash, string salt)
    {
        var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

        user.PasswordHash = passwordHash;
        user.Salt = salt;

        await _appDbContext.SaveChangesAsync();
    }

    public async Task UpdatePhoneAsync(Guid userId, string phone)
    {
        var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

        user.Phone = phone;

        await _appDbContext.SaveChangesAsync();
    }
}
