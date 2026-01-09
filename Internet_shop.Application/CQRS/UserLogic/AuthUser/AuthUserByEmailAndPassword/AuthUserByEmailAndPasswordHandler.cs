using Internet_shop.Application.Contracts.UserContracts;
using Internet_shop.Domain.Models.UserData;
using MediatR;

namespace Internet_shop.Application.CQRS.UserLogic.AuthUser.AuthUserByEmailAndPassword;

public class AuthUserByEmailAndPasswordHandler : IRequestHandler<AuthUserByEmailAndPasswordCommand, AuthDataResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;
    private readonly IUserUpdateRepository _userUpdateRepository;
    public AuthUserByEmailAndPasswordHandler(IUserRepository userRepository, IAuthService authService, IUserUpdateRepository userUpdateRepository)
    {
        _userRepository = userRepository;
        _authService = authService;
        _userUpdateRepository = userUpdateRepository;
    }

    public async Task<AuthDataResult> Handle(AuthUserByEmailAndPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserProfileByIdAsync(request.UserId);

        if (user.Password != null)
        {
            if(user.Password.VerifyPassword(request.Password))            
                return await _authService.GetCustomerWithTokensAsync(request.UserId); 
            
            else throw new InvalidOperationException("Invalid password. Please try again.");
        }
        else
        {
            var newPassword = new PasswordData(request.Password);
            await _userUpdateRepository.UpdatePasswordAsync(request.UserId, newPassword.PasswordHash, newPassword.Salt);
            return await _authService.GetCustomerWithTokensAsync(request.UserId);
        }        
    }
}
