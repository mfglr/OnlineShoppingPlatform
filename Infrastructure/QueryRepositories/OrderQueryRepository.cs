using Application.Queries.OrderAggregate;
using Application.QueryRepositories;
using Core;
using Domain.OrderAggregate.Entities;
using Domain.OrderAggregate.ValueObjects;
using Infrastructure.Contexts;
using Infrastructure.Extentions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.QueryRepositories
{
    internal static class OrderQuearyableMapper{
        public static IQueryable<OrderResponseDto> ToOrderReponseDto(this IQueryable<Order> query)
            => query
                .Select(
                    x => new OrderResponseDto(
                        x.Id,
                        x.Items.Select(
                            x =>
                            new OrderItemResponseDto(
                                x.ProductId,
                                x.Name,
                                x.Price,
                                x.Quantity
                            )
                        ),
                        x.State
                    )
                );
    }

    internal class OrderQueryRepository(AppDbContext context) : IOrderQueryRepository
    {
        private readonly AppDbContext _context = context;

        public Task<List<OrderResponseDto>> GetOrdersByUserIdAsync(int userId, Page page, CancellationToken cancellationToken)
            => _context.Orders
                .AsNoTracking()
                .Where(x => x.UserId == userId)
                .ToPage(page)
                .ToOrderReponseDto()
                .ToListAsync(cancellationToken);

        public Task<List<OrderResponseDto>> GetOrdersByUserIdAndStateAsync(int userId, OrderState state, Page page, CancellationToken cancellationToken)
            => _context.Orders
                .AsNoTracking()
                .Where(x => x.UserId == userId && x.State == state)
                .ToPage(page)
                .ToOrderReponseDto()
                .ToListAsync(cancellationToken);
    }
}
