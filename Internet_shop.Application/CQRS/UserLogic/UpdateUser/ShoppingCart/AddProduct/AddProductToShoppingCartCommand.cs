using MediatR;

namespace Internet_shop.Application.CQRS.UserLogic.UpdateUser.ShoppingCart.AddProduct;

public class AddProductToShoppingCartCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }  
}
