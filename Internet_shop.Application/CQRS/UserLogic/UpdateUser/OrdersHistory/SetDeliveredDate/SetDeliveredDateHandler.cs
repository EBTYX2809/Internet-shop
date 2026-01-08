using Internet_shop.Application.Contracts.UserContracts;
using MediatR;

namespace Internet_shop.Application.CQRS.UserLogic.UpdateUser.OrdersHistory.SetDeliveredDate;

public class SetDeliveredDateHandler : IRequestHandler<SetDeliveredDateCommand>
{
    private readonly IOrderRepository _orderRepository;

    public SetDeliveredDateHandler(IOrderRepository orderRepository)
        => _orderRepository = orderRepository;

    public async Task Handle(SetDeliveredDateCommand request, CancellationToken cancellationToken)
    {
        await _orderRepository.SetDeliveredDateAsync(request.OrderId, request.DeliveredDate);
    }
}
