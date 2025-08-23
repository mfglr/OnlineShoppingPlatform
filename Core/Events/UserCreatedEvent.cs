using MediatR;

namespace Core.Events
{
    public record UserCreatedEvent(string Email, string EmailConfirmationToken) : INotification;
}
