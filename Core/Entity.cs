using MassTransit;

namespace Core
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; } = NewId.NextSequentialGuid();
        public DateTime CreatedAt { get; protected set; }
        public DateTime? UpdatedAt { get; protected set; }


        public virtual void Create() => CreatedAt = DateTime.UtcNow;
    }
}
