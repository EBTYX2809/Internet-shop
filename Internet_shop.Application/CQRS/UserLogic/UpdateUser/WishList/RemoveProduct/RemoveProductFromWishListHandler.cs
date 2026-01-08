using Internet_shop.Application.Contracts.UserContracts;
using MediatR;

namespace Internet_shop.Application.CQRS.UserLogic.UpdateUser.WishList.RemoveProduct;

public class RemoveProductFromWishListHandler : IRequestHandler<RemoveProductFromWishListCommand>
{
    private readonly IWishListRepository _wishListRepository;

    public RemoveProductFromWishListHandler(IWishListRepository wishListRepository)
        => _wishListRepository = wishListRepository;

    public async Task Handle(RemoveProductFromWishListCommand request, CancellationToken cancellationToken)
    {
        await _wishListRepository.RemoveProductAsync(request.UserId, request.ProductId);
    }
}
