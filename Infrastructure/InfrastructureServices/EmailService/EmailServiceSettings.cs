using Application.InfrastructureServices.EmailService;

namespace Infrastructure.InfrastructureServices.EmailService
{
    public record EmailServiceSettings(string Host, int Port, string SenderMail, string DisplayName, string Password) : IEmailServiceSettings;
    
}
