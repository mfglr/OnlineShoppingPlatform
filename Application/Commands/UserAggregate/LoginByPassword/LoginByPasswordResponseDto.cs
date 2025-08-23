namespace Application.Commands.UserAggregate.LoginByPassword
{
    public record LoginByPasswordResponseDto(string AccessToken, string RefreshToken);
}
