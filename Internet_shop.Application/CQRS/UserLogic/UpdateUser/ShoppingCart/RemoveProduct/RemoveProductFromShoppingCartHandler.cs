using Internet_shop.Application.Contracts.UserContracts;
using MediatR;

namespace Internet_shop.Application.CQRS.UserLogic.UpdateUser.ShoppingCart.RemoveProduct;

public class RemoveProductFromShoppingCartHandler : IRequestHandler<RemoveProductFromShoppingCartCommand>
{
    private readonly IShoppingCartRepository _shoppingCartRepository;

    public RemoveProductFromShoppingCartHandler(IShoppingCartRepository shoppingCartRepository)
        => _shoppingCartRepository = shoppingCartRepository;

    public async Task Handle(RemoveProductFromShoppingCartCommand request, CancellationToken cancellationToken)
    {
        await _shoppingCartRepository.RemoveProductAsync(request.UserId, request.ProductId);
    }
}
