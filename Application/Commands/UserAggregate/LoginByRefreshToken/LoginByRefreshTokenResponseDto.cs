namespace Application.Commands.UserAggregate.LoginByRefreshToken
{
    public record LoginByRefreshTokenResponseDto(string AccessToken, string RefreshToken);
}