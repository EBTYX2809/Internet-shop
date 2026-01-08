using Internet_shop.Application.Contracts.UserContracts;
using Internet_shop.Domain.Models.UserData;
using MediatR;

namespace Internet_shop.Application.CQRS.UserLogic.CreateUser;

public class CreateCustomerHandler : IRequestHandler<CreateGuestCustomerCommand, Guid>
{
    private readonly IUserRepository _userRepository;

    public CreateCustomerHandler(IUserRepository userRepository)
        => _userRepository = userRepository;

    public async Task<Guid> Handle(CreateGuestCustomerCommand request, CancellationToken cancellationToken)
    {
        var user = new Customer();

        await _userRepository.CreateAsync(user.Id);

        return user.Id;
    }
}
