using Internet_shop.Domain.Models;

namespace Internet_shop.Application.Contracts;

public interface IUserRepository
{
    Task CreateUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(Guid userId);
    Task<User?> GetUserById(Guid userId);    
}
