using MediatR;

namespace Core.Events
{
    public record ProductDeletedEvent(int ProductId) : INotification;
}
