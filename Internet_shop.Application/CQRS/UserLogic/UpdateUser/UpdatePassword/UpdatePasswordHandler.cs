using Internet_shop.Application.Contracts.UserContracts;
using Internet_shop.Domain.Models.UserData;
using MediatR;

namespace Internet_shop.Application.CQRS.UserLogic.UpdateUser.UpdatePassword;

public class UpdatePasswordHandler : IRequestHandler<UpdatePasswordCommand>
{
    private readonly IUserUpdateRepository _userUpdateRepository;

    public UpdatePasswordHandler(IUserUpdateRepository userUpdateRepository)
        => _userUpdateRepository = userUpdateRepository;

    public async Task Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
    {
        var passwordData = new PasswordData(request.Password);

        await _userUpdateRepository.UpdatePasswordAsync(request.UserId, passwordData.PasswordHash, passwordData.Salt);
    }
}
