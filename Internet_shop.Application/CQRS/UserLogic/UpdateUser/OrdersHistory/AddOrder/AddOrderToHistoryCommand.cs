using Internet_shop.Domain.Models.UserData;
using MediatR;

namespace Internet_shop.Application.CQRS.UserLogic.UpdateUser.OrdersHistory.AddOrder;

public class AddOrderToHistoryCommand : IRequest
{
    public Order Order { get; set; }
}
