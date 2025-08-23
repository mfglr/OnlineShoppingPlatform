using Application.InfrastructureServices.EmailService;
using Core.Events;
using MediatR;

namespace Application.DomainEventConsumers.UserCreatedEventConsumers
{
    internal class SendEmailConfirmationMail(IEmailService emailService) : INotificationHandler<UserCreatedEvent>
    {
        private readonly IEmailService _emailService = emailService;

        public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {
            await _emailService.SendEmailVerificationMail(notification.EmailConfirmationToken, notification.Email, cancellationToken);
        }
    }
}
