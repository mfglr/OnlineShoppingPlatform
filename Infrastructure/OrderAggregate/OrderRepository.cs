using Domain.OrderAggregate.Abstracts;
using Domain.OrderAggregate.Entities;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.OrderAggregate
{
    internal class OrderRepository(AppDbContext context) : Repository<Order>(context), IOrderRepository
    {
        public Task<List<Order>> GetOrdersByUserId(Guid userId, CancellationToken cancellationToken)
            => _context.Orders.Where(x => x.UserId == userId).ToListAsync(cancellationToken);

        public override Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => _context.Orders.Include(x => x.Items).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}
