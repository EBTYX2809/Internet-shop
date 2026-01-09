using Internet_shop.Application.Contracts.UserContracts;
using MediatR;

namespace Internet_shop.Application.CQRS.UserLogic.AuthUser.AuthUserByGoogleOAuth.GetGoogleAuthenticationUrl;

public class GetGoogleAuthenticationUrlHandler : IRequestHandler<GetGoogleAuthenticationUrlCommand, string>
{
    private readonly IAuthService _authService;

    public GetGoogleAuthenticationUrlHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<string> Handle(GetGoogleAuthenticationUrlCommand request, CancellationToken cancellationToken)
    {
        return await _authService.GetGoogleAuthenticationUrlAsync(request.CodeChallenge, request.State);
    }
}
