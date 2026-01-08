using MediatR;

namespace Internet_shop.Application.CQRS.UserLogic.UpdateUser.ShoppingCart.RemoveProduct;

public class RemoveProductFromShoppingCartCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
}
