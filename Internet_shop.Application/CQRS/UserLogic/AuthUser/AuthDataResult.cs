using Internet_shop.Domain.Models.UserData;

namespace Internet_shop.Application.CQRS.UserLogic.AuthUser;

public class AuthDataResult
{
    public Customer Customer { get; init; } = new();
    public string AccessToken { get; init; } = string.Empty;
    public string RefreshToken { get; init; } = string.Empty;
    public AuthDataResult(Customer customer, string accessToken, string refreshToken)
    {
        Customer = customer;
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }
}
