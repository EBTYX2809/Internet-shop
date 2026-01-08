using MediatR;

namespace Internet_shop.Application.CQRS.UserLogic.UpdateUser.WishList.RemoveProduct;

public class RemoveProductFromWishListCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
}
