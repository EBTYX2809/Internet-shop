using Internet_shop.Application.Contracts.UserContracts;
using MediatR;

namespace Internet_shop.Application.CQRS.UserLogic.AuthUser.AuthUserByGoogleOAuth.GetCustomerByGoogleCode;

public class GetCustomerByGoogleCodeHandler : IRequestHandler<GetCustomerByGoogleCodeCommand, AuthDataResult>
{
    private readonly IAuthService _authService;

    public GetCustomerByGoogleCodeHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<AuthDataResult> Handle(GetCustomerByGoogleCodeCommand request, CancellationToken cancellationToken)
    {
        return await _authService.GetCustomerByGoogleCodeAsync(request.Code, request.CodeVerifier);
    }
}
