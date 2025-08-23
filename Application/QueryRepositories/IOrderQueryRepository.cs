using Application.Queries.OrderAggregate;
using Core;
using Domain.OrderAggregate.ValueObjects;

namespace Application.QueryRepositories
{
    public interface IOrderQueryRepository
    {
        Task<List<OrderResponseDto>> GetOrdersByUserIdAsync(int userId, Page page, CancellationToken cancellationToken);
        Task<List<OrderResponseDto>> GetOrdersByUserIdAndStateAsync(int userId, OrderState state, Page page, CancellationToken cancellationToken);
    }
}
