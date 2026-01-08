using MediatR;

namespace Internet_shop.Application.CQRS.UserLogic.UpdateUser.WishList.AddProduct;

public class AddProductToWishListCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
}
