using MediatR;

namespace Application.Commands.UserAggregate.LoginByRefreshToken
{
    public record LoginByRefreshTokenDto(int Id, string RefreshToken) : IRequest<LoginByRefreshTokenResponseDto>;
}
