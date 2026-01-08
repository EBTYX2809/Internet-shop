using Internet_shop.Application.Contracts.UserContracts;
using MediatR;

namespace Internet_shop.Application.CQRS.UserLogic.UpdateUser.WishList.Clear;

public class ClearWishListHandler : IRequestHandler<ClearWishListCommand>
{
    private readonly IWishListRepository _wishListRepository;

    public ClearWishListHandler(IWishListRepository wishListRepository)
        => _wishListRepository = wishListRepository;

    public async Task Handle(ClearWishListCommand request, CancellationToken cancellationToken)
    {
        await _wishListRepository.ClearWishListAsync(request.UserId);
    }
}
