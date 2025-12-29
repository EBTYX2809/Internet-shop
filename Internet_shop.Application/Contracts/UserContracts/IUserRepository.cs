using Internet_shop.Domain.Models.UserData;

namespace Internet_shop.Application.Contracts.UserContracts;

public interface IUserRepository
{
    Task CreateAsync(Guid guestId);
    Task DeleteAsync(Guid userId);
    Task<Customer?> GetCustomerByIdAsync(Guid customerId);
    Task<User?> GetUserProfileByIdAsync(Guid userId);    
}
