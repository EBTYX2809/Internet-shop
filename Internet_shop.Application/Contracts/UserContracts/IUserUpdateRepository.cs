using Internet_shop.Domain.Models.UserData;

namespace Internet_shop.Application.Contracts.UserContracts;

public interface IUserUpdateRepository
{
    Task UpdateEmailAsync(Guid userId, string email);
    Task UpdatePasswordAsync(Guid userId, string passwordHash, string salt);
    Task UpdatePhoneAsync(Guid userId, string phone);
    Task UpdateAddressAsync(Guid userId, UserAddress address);
    Task UpdateGuestToUserAsync(Guid userId);
}
