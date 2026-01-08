using MediatR;

namespace Internet_shop.Application.CQRS.UserLogic.UpdateUser.OrdersHistory.SetDeliveredDate;

public class SetDeliveredDateCommand : IRequest
{
    public Guid OrderId { get; set; }
    public DateTime DeliveredDate { get; set; }
}
