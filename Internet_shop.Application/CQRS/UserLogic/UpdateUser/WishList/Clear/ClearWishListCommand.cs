using MediatR;

namespace Internet_shop.Application.CQRS.UserLogic.UpdateUser.WishList.Clear;

public class ClearWishListCommand : IRequest 
{ 
    public Guid UserId { get; set; }
}
