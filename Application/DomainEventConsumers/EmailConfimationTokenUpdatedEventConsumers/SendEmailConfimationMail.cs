using Application.InfrastructureServices.EmailService;
using Core.Events;
using MediatR;

namespace Application.DomainEventConsumers.EmailConfimationTokenUpdatedEventConsumers
{
    internal class SendEmailConfimationMail(IEmailService emailService) : INotificationHandler<EmailConfimationTokenUpdatedEvent>
    {
        private readonly IEmailService _emailService = emailService;

        public async Task Handle(EmailConfimationTokenUpdatedEvent notification, CancellationToken cancellationToken)
        {
            await _emailService.SendEmailVerificationMail(notification.Token, notification.Email, cancellationToken);
        }
    }
}
