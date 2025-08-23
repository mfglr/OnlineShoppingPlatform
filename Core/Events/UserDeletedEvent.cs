using MediatR;

namespace Core.Events
{
    public record UserDeletedEvent(int UserId) : INotification;
}
