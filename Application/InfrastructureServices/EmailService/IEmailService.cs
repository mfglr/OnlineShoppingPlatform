namespace Application.InfrastructureServices.EmailService
{
    public interface IEmailService
    {
        Task SendEmailVerificationMail(string token, string email, CancellationToken cancellationToken);
        Task SendResetPasswordMailMessage(string token, string email, CancellationToken cancellationToken);
    }
}
