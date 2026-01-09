using Internet_shop.Application.CQRS.UserLogic.AuthUser;

namespace Internet_shop.Application.Contracts.UserContracts;

public interface IAuthService
{
    Task<AuthDataResult> GetCustomerWithTokensAsync(Guid userId);
    Task<string> GetGoogleAuthenticationUrlAsync(string codeChallenge, string state);
    Task<AuthDataResult> GetCustomerByGoogleCodeAsync(string code, string codeVerifier);
}
