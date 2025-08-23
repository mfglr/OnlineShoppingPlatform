using Domain.UserAggregate.Abstracts;
using Domain.UserAggregate.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.UserAggregate
{
    internal class AccessTokenGenerator(ITokenProviderOptions tokenProviderOptions) : IAccessTokenGenerator
    {
        private readonly ITokenProviderOptions _tokenProviderOptions = tokenProviderOptions;

        private List<Claim> GetClaims(User user) => 
        [
            new (JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            new (JwtRegisteredClaimNames.Aud, _tokenProviderOptions.Audience),
            new (ClaimTypes.NameIdentifier, user.Id.ToString()),
            new (ClaimTypes.Role, user.Role.ToString())
        ];

        public string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenProviderOptions.SecurityKey));
            var expirationDateOfAccessToken = DateTime.Now.AddMinutes(_tokenProviderOptions.AccessTokenExpiration);
            JwtSecurityToken jwtSecurityToken = new(
                issuer: _tokenProviderOptions.Issuer,
                expires: expirationDateOfAccessToken,
                notBefore: DateTime.Now,
                claims: GetClaims(user),
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            );
            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}
