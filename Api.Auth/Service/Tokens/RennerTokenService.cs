using Api.Auth.Models;
using Api.Auth.Service.Interface;

namespace Api.Auth.Service.Tokens
{
    public class RennerTokenService : ITokenBaseService
    {
        public string GetToken()
        {
            return "Renner token";
        }

        public string RefreshToken(string oldToken)
        {
            return "Renner refresh token";
        }
    }
}
