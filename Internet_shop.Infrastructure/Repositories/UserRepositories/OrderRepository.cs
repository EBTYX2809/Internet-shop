using Internet_shop.Application.Contracts.UserContracts;
using Internet_shop.Domain.Models.UserData;
using Internet_shop.Infrastructure.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;

namespace Internet_shop.Infrastructure.Repositories.UserRepositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _appDbContext;

    public OrderRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task AddOrderAsync(Order order)
    {
        var orderEntity = new OrderEntity()
        {
            Id = order.Id,
            UserId = order.UserId,
            CreatedDate = order.CreatedDate,
            Products = order.Products.Select(p => new OrderItemEntity()
            {
                Id = Guid.NewGuid(),
                ProductId = p.Id,
                OrderId = order.Id
            }).ToList()
        };

        await _appDbContext.Orders.AddAsync(orderEntity);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task SetDeliveredDateAsync(Guid orderId, DateTime date)
    {
        var orderEntity = await _appDbContext.Orders.FirstOrDefaultAsync(o => o.Id == orderId);

        orderEntity.DeliveredDate = date;

        await _appDbContext.SaveChangesAsync();
    }
}
