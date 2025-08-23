namespace Core
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime? UpdatedAt { get; protected set; }

        public virtual void Create() => CreatedAt = DateTime.UtcNow;
    }
}
