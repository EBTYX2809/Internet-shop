using Internet_shop.Domain.Models.UserData;

namespace Internet_shop.Application.Contracts;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(Guid userId);
    Task<User?> GetByIdAsync(Guid userId);    
}
