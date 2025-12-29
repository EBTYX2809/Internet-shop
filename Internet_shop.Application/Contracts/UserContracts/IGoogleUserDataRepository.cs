using Internet_shop.Domain.Models.UserData;

namespace Internet_shop.Application.Contracts.UserContracts;

public interface IGoogleUserDataRepository
{
    Task AddGoogleIdAsync(GoogleUserData data);
    Task<Customer?> GetCustomerByGoogleIdAsync(string googleId);
    Task DeleteGoogleUserDataAsync(GoogleUserData data);
}
