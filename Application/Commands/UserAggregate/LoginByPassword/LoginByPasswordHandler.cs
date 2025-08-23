using Domain.UserAggregate.Abstracts;
using Domain.UserAggregate.Exceptions;
using MediatR;

namespace Application.Commands.UserAggregate.LoginByPassword
{
    internal class LoginByPasswordHandler(IUserRepository userRepository,IAccessTokenGenerator accessTokenGenerator) : IRequestHandler<LoginByPasswordDto, LoginByPasswordResponseDto>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IAccessTokenGenerator _accessTokenGenerator = accessTokenGenerator;

        public async Task<LoginByPasswordResponseDto> Handle(LoginByPasswordDto request, CancellationToken cancellationToken)
        {
            var user =
                await _userRepository.GetUserByEmailAsync(request.Email, cancellationToken) ??
                throw new UserNotFoundException();
            user.LoginByPassword(request.Password);
            return new(_accessTokenGenerator.Generate(user),user.RefreshToken.Value);
        }
    }
}
