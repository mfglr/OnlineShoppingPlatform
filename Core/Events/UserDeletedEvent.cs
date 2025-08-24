using MediatR;

namespace Core.Events
{
    public record UserDeletedEvent(Guid UserId) : INotification;
}
