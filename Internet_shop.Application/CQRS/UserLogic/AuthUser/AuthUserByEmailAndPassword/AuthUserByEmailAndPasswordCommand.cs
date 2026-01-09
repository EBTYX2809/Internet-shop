using MediatR;

namespace Internet_shop.Application.CQRS.UserLogic.AuthUser.AuthUserByEmailAndPassword;

public class AuthUserByEmailAndPasswordCommand : IRequest<AuthDataResult>
{
    public Guid UserId { get; set; } // Guest
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}
