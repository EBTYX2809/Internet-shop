using MediatR;

namespace Internet_shop.Application.CQRS.UserLogic.AuthUser.AuthUserByGoogleOAuth.GetCustomerByGoogleCode;

public class GetCustomerByGoogleCodeCommand : IRequest<AuthDataResult>
{
    public string Code { get; init; } = string.Empty;
    public string CodeVerifier { get; init; } = string.Empty;
}
