using Internet_shop.Application.Contracts.UserContracts;
using MediatR;

namespace Internet_shop.Application.CQRS.UserLogic.UpdateUser.UpdateEmail;

public class UpdateEmailHandler : IRequestHandler<UpdateEmailCommand>
{
    private readonly IUserUpdateRepository _userUpdateRepository;

    public UpdateEmailHandler(IUserUpdateRepository userUpdateRepository)                         
        => _userUpdateRepository = userUpdateRepository;

    public async Task Handle(UpdateEmailCommand request, CancellationToken cancellationToken)
    {
        await _userUpdateRepository.UpdateEmailAsync(request.UserId, request.Email);
    }
}
