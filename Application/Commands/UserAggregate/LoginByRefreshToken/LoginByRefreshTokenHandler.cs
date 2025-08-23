using Domain.UserAggregate.Abstracts;
using Domain.UserAggregate.Exceptions;
using MediatR;

namespace Application.Commands.UserAggregate.LoginByRefreshToken
{
    internal class LoginByRefreshTokenHandler(IUserRepository userRepository, IAccessTokenGenerator accessTokenGenerator) : IRequestHandler<LoginByRefreshTokenDto, LoginByRefreshTokenResponseDto>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IAccessTokenGenerator _accessTokenGenerator = accessTokenGenerator;

        public async Task<LoginByRefreshTokenResponseDto> Handle(LoginByRefreshTokenDto request, CancellationToken cancellationToken)
        {
            var user = 
                await _userRepository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new UserNotFoundException();
            user.LoginByRefreshToken(request.RefreshToken);
            return new(_accessTokenGenerator.Generate(user), user.RefreshToken.Value);
        }
    }
}
