namespace Domain.UserAggregate.Abstracts
{
    public interface ITokenProviderOptions
    {
        string Audience { get; }
        string Issuer { get; }
        int AccessTokenExpiration { get; }
        int RefreshTokenExpiration { get; }
        string SecurityKey { get; }
    }
}
