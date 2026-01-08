using Internet_shop.Application.Contracts.UserContracts;
using MediatR;

namespace Internet_shop.Application.CQRS.UserLogic.UpdateUser.UpdateAddress;

public class UpdateAddressHandler : IRequestHandler<UpdateAddressCommand>
{
    private readonly IUserUpdateRepository _userUpdateRepository;

    public UpdateAddressHandler(IUserUpdateRepository userUpdateRepository)
        => _userUpdateRepository = userUpdateRepository;

    public async Task Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        await _userUpdateRepository.UpdateAddressAsync(request.UserId, request.Address);
    }
}
