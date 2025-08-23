using Core.Events;
using Domain.UserAggregate.Abstracts;
using Domain.UserAggregate.Exceptions;
using MediatR;

namespace Application.Commands.UserAggregate.GenereatePasswordResetToken
{
    internal class GeneratePasswordResetTokenHandler(IPublisher publisher, IUserRepository userRepository) : IRequestHandler<GeneratePasswordResetTokenDto>
    {
        private readonly IPublisher _publisher = publisher;
        private readonly IUserRepository _userRepository = userRepository;

        public async Task Handle(GeneratePasswordResetTokenDto request, CancellationToken cancellationToken)
        {
            var user = 
                await _userRepository.GetUserByEmailAsync(request.Email, cancellationToken) ??
                throw new UserNotFoundException();
            user.UpdatePasswordResetToken();
            await _publisher.Publish(
                new PasswordResetTokenUpdatedEvent(user.Email.Value, user.PasswordResetToken!.Value),
                cancellationToken
            );
        }
    }
}
