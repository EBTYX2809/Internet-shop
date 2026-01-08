using Internet_shop.Application.Contracts.UserContracts;
using MediatR;

namespace Internet_shop.Application.CQRS.UserLogic.UpdateUser.UpdatePhone;

public class UpdatePhoneHandler : IRequestHandler<UpdatePhoneCommand>
{
    private readonly IUserUpdateRepository _userUpdateRepository;

    public UpdatePhoneHandler(IUserUpdateRepository userUpdateRepository)
        => _userUpdateRepository = userUpdateRepository;

    public async Task Handle(UpdatePhoneCommand request, CancellationToken cancellationToken)
    {
        await _userUpdateRepository.UpdatePhoneAsync(request.UserId, request.Phone);
    }
}
