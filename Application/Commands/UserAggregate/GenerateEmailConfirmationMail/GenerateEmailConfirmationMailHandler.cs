using Application.InfrastructureServices;
using Core.Events;
using MediatR;

namespace Application.Commands.UserAggregate.GenerateEmailConfirmationMail
{
    internal class GenerateEmailConfirmationMailHandler(IUserAccessor userAccessor, IPublisher publisher) : IRequestHandler<GenerateEmailConfirmationMailDto>
    {
        private readonly IUserAccessor _userAccessor = userAccessor;
        private readonly IPublisher _publisher = publisher;
        public async Task Handle(GenerateEmailConfirmationMailDto notification, CancellationToken cancellationToken)
        {
            var user = _userAccessor.User;
            user.UpdateEmailConfirmationToken();
            await _publisher.Publish(
                new EmailConfimationTokenUpdatedEvent(user.Email.Value,user.EmailConfirmationToken!.Value),
                cancellationToken
            );
        }
    }
}
