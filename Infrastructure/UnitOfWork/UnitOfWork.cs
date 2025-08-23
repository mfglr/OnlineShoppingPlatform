using Core.Abstracts;
using Infrastructure.Contexts;

namespace Infrastructure.UnitOfWork
{
    internal class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        private readonly AppDbContext _context = context;

        public Task CommitAsync(CancellationToken cancellationToken)
            => _context.SaveChangesAsync(cancellationToken);
    }
}
