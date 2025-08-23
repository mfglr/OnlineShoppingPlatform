using Core.Abstracts;
using Domain.OrderAggregate.Entities;

namespace Domain.OrderAggregate.Abstracts
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<List<Order>> GetOrdersByUserId(int userId, CancellationToken cancellationToken);
    }
}
