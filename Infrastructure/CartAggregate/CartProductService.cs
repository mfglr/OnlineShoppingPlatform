using Domain.CartAggregate.Abstracts;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.CartAggregate
{
    internal class CartProductService(AppDbContext context) : ICartProductService
    {
        private readonly AppDbContext _context = context;
        public async Task<int> GetProductStock(int productId, CancellationToken cancellationToken)
            => 
                (await _context.Products.FirstOrDefaultAsync(x => x.Id == productId, cancellationToken))?.StockQuantity ??
                await Task.FromResult(0);
    }
}
