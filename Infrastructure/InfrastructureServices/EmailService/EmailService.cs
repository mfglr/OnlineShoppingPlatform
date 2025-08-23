using Application.InfrastructureServices.EmailService;
using Infrastructure.InfrastructureServices.EmailService.MailMessageFactories;
using System.Net.Mail;

namespace Infrastructure.InfrastructureServices.EmailService
{
    internal class EmailService(EmailVerificationMailMessageFactory emailVerificationMailMessageFactory, ResetPasswordMailMessgeFactory resetPasswordMailMessgeFactory, SmtpClient smtpClient) : IEmailService
    {
        private readonly EmailVerificationMailMessageFactory _emailVerificationMailMessageFactory = emailVerificationMailMessageFactory;
        private readonly ResetPasswordMailMessgeFactory _resetPasswordMailMessgeFactory = resetPasswordMailMessgeFactory;

        private readonly SmtpClient _smtpClient = smtpClient;

        public async Task SendEmailVerificationMail(string token, string email, CancellationToken cancellationToken)
        {
            var mailMessage = await _emailVerificationMailMessageFactory.Create(token, email, cancellationToken);
            await _smtpClient.SendMailAsync(mailMessage, cancellationToken);
        }

        public async Task SendResetPasswordMailMessage(string token, string email, CancellationToken cancellationToken)
        {
            var mailMessage = await _resetPasswordMailMessgeFactory.Create(token, email, cancellationToken);
            await _smtpClient.SendMailAsync(mailMessage, cancellationToken);
        }
    }
}
