namespace Core.Abstracts
{
    public interface IRepository<E> where E : Entity
    {
        Task CreateAsync(E entity, CancellationToken cancellationToken);
        Task<E?> GetByIdAsync(int id, CancellationToken cancellationToken);
        void Delete(E entity);
        void DeleteRange(IEnumerable<E> entities);
    }
}
