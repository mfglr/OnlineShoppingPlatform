using Core;
using Core.Abstracts;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class Repository<E>(AppDbContext context) : IRepository<E> where E : Entity
    {
        protected readonly AppDbContext _context = context;
        private readonly DbSet<E> _dbSet = context.Set<E>();

        public async Task CreateAsync(E entity, CancellationToken cancellationToken)
            => await _dbSet.AddAsync(entity, cancellationToken);

        public void Delete(E entity)
            => _dbSet.Remove(entity);

        public void DeleteRange(IEnumerable<E> entities)
            => _dbSet.RemoveRange(entities);

        public virtual async Task<E?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => await _dbSet.FindAsync([id], cancellationToken: cancellationToken);
    }
}
