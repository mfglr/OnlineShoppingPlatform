using Application.InfrastructureServices.EmailService;
using System.Net.Mail;

namespace Infrastructure.InfrastructureServices.EmailService.MailMessageFactories
{
    public class EmailVerificationMailMessageFactory(IEmailServiceSettings emailServiceSettings)
    {
        private readonly IEmailServiceSettings _emailServiceSettings = emailServiceSettings;

        public async Task<MailMessage> Create(string token, string email, CancellationToken cancellationToken)
        {
            using var file = File.OpenRead($"MailMessages/EmailVerification.html");
            using var streamReader = new StreamReader(file);

            var body = await streamReader.ReadToEndAsync(cancellationToken);
            body = body.Replace("{email}", email);
            body = body.Replace("{token}", token);

            var message = new MailMessage()
            {
                IsBodyHtml = true,
                From = new MailAddress(_emailServiceSettings.SenderMail, _emailServiceSettings.DisplayName),
                Subject = "Email Confirmation",
                Body = body
            };
            message.To.Add(new MailAddress(email));

            return message;
        }
    }
}
