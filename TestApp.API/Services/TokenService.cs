using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using TestApp.API.Services.Interfaces;
using TestApp.Core.Application.Login.ViewModels;
using TestApp.Core.Entities;


namespace TestApp.API.Services
{
    public class TokenService: ITokenService
    {
        private readonly TokenOptions tokenOptions;

        public TokenService(IOptions<TokenOptions> tokenOptions)
        {
            this.tokenOptions = tokenOptions.Value;
        }

        public AccessToken CreateAccessToken(User user)
        {
            var accessTokenExpiration = DateTime.Now.AddDays(tokenOptions.AccessTokenExpiration);

            var securityKey = SignHandler.GetSecurityKey(tokenOptions.SecurityKey);

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: GetClaim(user),
                signingCredentials: signingCredentials

                );

            var handler = new JwtSecurityTokenHandler();

            var token = handler.WriteToken(jwtSecurityToken);

            AccessToken accessToken = new AccessToken();

            accessToken.Token = token;
            accessToken.RefreshToken = CreateRefreshToken();
            accessToken.Expiration = accessTokenExpiration;

            return accessToken;
        }

        private string CreateRefreshToken()
        {
            var numberByte = new Byte[32];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(numberByte);

                return Convert.ToBase64String(numberByte);
            }
        }

        private IEnumerable<Claim> GetClaim(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(ClaimTypes.Name,$"{user.FirstName} {user.LastName}"),              
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            return claims;
        }

        public void RevokeRefreshToken(User user)
        {
            user.RefreshToken = null;
        }
    }
}
