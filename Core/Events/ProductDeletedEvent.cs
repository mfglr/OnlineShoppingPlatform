using MediatR;

namespace Core.Events
{
    public record ProductDeletedEvent(Guid ProductId) : INotification;
}
