using Internet_shop.Application.Contracts.UserContracts;
using MediatR;

namespace Internet_shop.Application.CQRS.UserLogic.UpdateUser.OrdersHistory.AddOrder;

public class AddOrderToHistoryHandler : IRequestHandler<AddOrderToHistoryCommand>
{
    private readonly IOrderRepository _orderRepository;

    public AddOrderToHistoryHandler(IOrderRepository orderRepository)
        => _orderRepository = orderRepository;

    public async Task Handle(AddOrderToHistoryCommand request, CancellationToken cancellationToken)
    {
        await _orderRepository.AddOrderAsync(request.Order);
    }
}
