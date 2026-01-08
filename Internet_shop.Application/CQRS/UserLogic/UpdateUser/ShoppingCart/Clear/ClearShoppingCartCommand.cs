using MediatR;

namespace Internet_shop.Application.CQRS.UserLogic.UpdateUser.ShoppingCart.Clear;

public class ClearShoppingCartCommand : IRequest
{
    public Guid UserId { get; set; }
}
