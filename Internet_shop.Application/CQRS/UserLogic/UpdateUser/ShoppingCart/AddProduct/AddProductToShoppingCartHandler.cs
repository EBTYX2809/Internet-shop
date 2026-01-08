using Internet_shop.Application.Contracts.UserContracts;
using MediatR;

namespace Internet_shop.Application.CQRS.UserLogic.UpdateUser.ShoppingCart.AddProduct;

public class AddProductToShoppingCartHandler : IRequestHandler<AddProductToShoppingCartCommand>
{
    private readonly IShoppingCartRepository _shoppingCartRepository;

    public AddProductToShoppingCartHandler(IShoppingCartRepository shoppingCartRepository)
        => _shoppingCartRepository = shoppingCartRepository;

    public async Task Handle(AddProductToShoppingCartCommand request, CancellationToken cancellationToken)
    {
        await _shoppingCartRepository.AddProductAsync(request.UserId, request.ProductId);
    }
}
