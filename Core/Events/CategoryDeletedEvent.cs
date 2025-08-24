using MediatR;

namespace Core.Events
{
    public record CategoryDeletedEvent(Guid CategoryId) : INotification;
}
