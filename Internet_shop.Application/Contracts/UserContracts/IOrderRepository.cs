using Internet_shop.Domain.Models.UserData;

namespace Internet_shop.Application.Contracts.UserContracts;

public interface IOrderRepository
{
    Task AddOrderAsync(Order order);
    Task SetDeliveredDateAsync(Guid orderId, DateTime date);
}
