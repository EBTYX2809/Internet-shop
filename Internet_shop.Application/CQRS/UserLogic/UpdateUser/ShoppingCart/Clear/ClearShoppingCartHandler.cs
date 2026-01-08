using Internet_shop.Application.Contracts.UserContracts;
using MediatR;

namespace Internet_shop.Application.CQRS.UserLogic.UpdateUser.ShoppingCart.Clear;

public class ClearShoppingCartHandler : IRequestHandler<ClearShoppingCartCommand>
{
    private readonly IShoppingCartRepository _shoppingCartRepository;

    public ClearShoppingCartHandler(IShoppingCartRepository shoppingCartRepository)
        => _shoppingCartRepository = shoppingCartRepository;

    public async Task Handle(ClearShoppingCartCommand request, CancellationToken cancellationToken)
    {
        await _shoppingCartRepository.ClearCartAsync(request.UserId);
    }
}
