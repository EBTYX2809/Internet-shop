using Internet_shop.Application.Contracts.UserContracts;
using MediatR;

namespace Internet_shop.Application.CQRS.UserLogic.UpdateUser.WishList.AddProduct;

public class AddProductToWishListHandler : IRequestHandler<AddProductToWishListCommand>
{
    private readonly IWishListRepository _wishListRepository;

    public AddProductToWishListHandler(IWishListRepository wishListRepository)
        => _wishListRepository = wishListRepository;

    public async Task Handle(AddProductToWishListCommand request, CancellationToken cancellationToken)
    {
        await _wishListRepository.AddProductAsync(request.UserId, request.ProductId);
    }
}
