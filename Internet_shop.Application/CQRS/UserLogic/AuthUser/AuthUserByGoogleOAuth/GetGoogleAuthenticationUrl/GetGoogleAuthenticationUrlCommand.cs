using MediatR;

namespace Internet_shop.Application.CQRS.UserLogic.AuthUser.AuthUserByGoogleOAuth.GetGoogleAuthenticationUrl;

public class GetGoogleAuthenticationUrlCommand : IRequest<string>
{
    public string CodeChallenge { get; init; } = string.Empty;
    public string State { get; init; } = string.Empty;
}
