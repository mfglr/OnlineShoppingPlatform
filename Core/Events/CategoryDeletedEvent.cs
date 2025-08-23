using MediatR;

namespace Core.Events
{
    public record CategoryDeletedEvent(int CategoryId) : INotification;
}
