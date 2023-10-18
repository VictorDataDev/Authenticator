using Api.Auth.Models.Request;
using Api.Auth.Service.Interface;

namespace Api.Auth.Service.Tokens
{
    public class TokenService : ITokenService
    {
        public string GetToken(AuthRequest tokenRequest)
        {
            switch (tokenRequest.ParametersForToken)
            {
                case 0:
                    return new DefaultTokenService().GetToken();
                case 1:
                    return new RennerTokenService().GetToken();
                default:
                    return string.Empty;
            }
        }

        public string RefreshToken(RefreshAuthRequest refreshTokenRequest)
        {
            switch (refreshTokenRequest.ParametersForToken)
            {
                case 0:
                    return new DefaultTokenService().RefreshToken(refreshTokenRequest.OldToken);

                case 1:
                    return new RennerTokenService().RefreshToken(refreshTokenRequest.OldToken);
                default:
                    return string.Empty;
            }
        }
    }
}
