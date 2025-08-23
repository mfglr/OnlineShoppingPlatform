using MediatR;

namespace Core.Events
{
    public record EmailConfimationTokenUpdatedEvent(string Email, string Token) : INotification;
}
