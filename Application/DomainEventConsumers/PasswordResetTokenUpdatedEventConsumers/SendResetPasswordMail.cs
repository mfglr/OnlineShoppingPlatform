using Application.InfrastructureServices.EmailService;
using Core.Events;
using MediatR;

namespace Application.DomainEventConsumers.PasswordResetTokenUpdatedEventConsumers
{
    internal class SendResetPasswordMail(IEmailService emailService) : INotificationHandler<PasswordResetTokenUpdatedEvent>
    {
        private readonly IEmailService _emailService = emailService;

        public async Task Handle(PasswordResetTokenUpdatedEvent notification, CancellationToken cancellationToken)
        {
            await _emailService.SendResetPasswordMailMessage(notification.Token, notification.Email, cancellationToken);
        }
    }
}
