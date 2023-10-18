using Api.Auth.Service.Interface;
using Api.Auth.Service.Tokens.Base;
using System.Security.Claims;

namespace Api.Auth.Service.Tokens
{
    public class DefaultTokenService : TokenGenerator, ITokenBaseService
    {
        internal readonly int expireTimer = 2;
        
        public string GetToken()
        {
            var claims = new ClaimsIdentity(
                new Claim[]
                 {
                     new Claim(ClaimTypes.NameIdentifier, "Default"),
                 });
            return GenerateToken(claims, expireTimer,"default".GetHashCode(), Settings.Secret);
        }

        public string RefreshToken(string oldToken)
        {
            return "Default refresh token";
        }
    }
}
