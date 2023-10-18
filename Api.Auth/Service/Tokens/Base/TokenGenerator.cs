using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Auth.Service.Tokens.Base
{
    public class TokenGenerator
    {
        internal readonly string defaultNameClaimIdentifyClient = "HashIdentifyClient";

        public string GenerateToken(ClaimsIdentity claims, int expiresTime,int hasIdentifyClient, string hashCodeSecret)
        {

            var defaultClaim = new Dictionary<string, object>();
            defaultClaim.Add(defaultNameClaimIdentifyClient, hasIdentifyClient);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(hashCodeSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Claims = defaultClaim,
                Expires = DateTime.UtcNow.AddHours(expiresTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public Dictionary<string, string> DecodeToken(string token)
        {
            var flags = new Dictionary<string, string>();

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDecode = tokenHandler.ReadJwtToken(token);

            flags.Add("HashIdentifyClient", (tokenDecode.Claims.FirstOrDefault(c => c.Type == "HashIdentifyClient")?.Value).ToString());

            return flags;
            
        }
    }
}
