using MediatR;

namespace Core.Events
{
    public record PasswordResetTokenUpdatedEvent(string Email, string Token) : INotification;
}
