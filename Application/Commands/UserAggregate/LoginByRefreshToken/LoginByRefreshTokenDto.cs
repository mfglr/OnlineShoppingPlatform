using MediatR;

namespace Application.Commands.UserAggregate.LoginByRefreshToken
{
    public record LoginByRefreshTokenDto(Guid Id, string RefreshToken) : IRequest<LoginByRefreshTokenResponseDto>;
}
