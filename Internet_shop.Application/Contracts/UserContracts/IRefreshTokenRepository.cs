using Internet_shop.Domain.Models.UserData;

namespace Internet_shop.Application.Contracts.UserContracts;

public interface IRefreshTokenRepository
{
    Task AddTokenAsync(RefreshToken token);
    Task<RefreshToken?> GetRefreshTokenAsync(Guid id);
    Task RevokeTokenAsync(Guid id);
    Task DeleteTokenAsync(RefreshToken token);
}
