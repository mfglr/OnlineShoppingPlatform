using Application.InfrastructureServices.EmailService;
using Infrastructure.InfrastructureServices.EmailService.MailMessageFactories;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Mail;

namespace Infrastructure.InfrastructureServices.EmailService
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddEmailService(this IServiceCollection services)
        {
            var emailServiceSettings = services.BuildServiceProvider().GetRequiredService<IEmailServiceSettings>()!;
            return services
                .AddScoped(
                    sp =>
                    {
                        return new SmtpClient()
                        {
                            Host = emailServiceSettings.Host,
                            Port = emailServiceSettings.Port,
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            UseDefaultCredentials = false,
                            Credentials = new NetworkCredential(emailServiceSettings.SenderMail, emailServiceSettings.Password),
                            EnableSsl = true
                        };
                    }
                )
                .AddScoped<IEmailService, EmailService>()
                .AddSingleton<ResetPasswordMailMessgeFactory>()
                .AddSingleton<EmailVerificationMailMessageFactory>();
        }
    }
}
