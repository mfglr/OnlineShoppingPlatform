using Domain.UserAggregate.Abstracts;

namespace Infrastructure.UserAggregate
{
    public class TokenProviderOptions(string audience, string issuer, int accessTokenExpiration, int refreshTokenExpiration, string securityKey) : ITokenProviderOptions
    {
        public string Audience { get; init; } = audience;
        public string Issuer { get; init; } = issuer;
        public int AccessTokenExpiration { get; init; } = accessTokenExpiration;
        public int RefreshTokenExpiration { get; init; } = refreshTokenExpiration;
        public string SecurityKey { get; init; } = securityKey;
    }
}
