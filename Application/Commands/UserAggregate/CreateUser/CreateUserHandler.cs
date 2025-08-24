using Core.Events;
using Domain.UserAggregate.Abstracts;
using Domain.UserAggregate.Entities;
using Domain.UserAggregate.Exceptions;
using Domain.UserAggregate.ValueObjects;
using MediatR;

namespace Application.Commands.UserAggregate.CreateUser
{
    internal class CreateUserHandler(IUserRepository userRepository, IAccessTokenGenerator accessTokenGenerator, IPublisher publisher) : IRequestHandler<CreateUserDto, CreateUserResponseDto>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IAccessTokenGenerator _accessTokenGenerator = accessTokenGenerator;
        private readonly IPublisher _publisher = publisher;

        public async Task<CreateUserResponseDto> Handle(CreateUserDto request, CancellationToken cancellationToken)
        {
            var email = new Email(request.Email);
            var password = new Password(request.Password);
            var passwordConfirm = new Password(request.PasswordConfirm);

            if (!password.CompareValue(passwordConfirm))
                throw new PassowordAndPasswordConfirmationNotMatchException();

            if (await _userRepository.IsEmailExistAsync(request.Email, cancellationToken))
                throw new EmailIsAlreadyTakenException();

            var user = new User(email, password);
            user.Create();
            await _userRepository.CreateAsync(user, cancellationToken);

            await _publisher.Publish(
                new UserCreatedEvent(user.Email.Value, user.EmailConfirmationToken!.Value),
                cancellationToken
            );

            return new(
                _accessTokenGenerator.Generate(user),
                user.RefreshToken.Value
            );

        }
    }
}
