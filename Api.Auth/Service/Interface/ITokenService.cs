using Api.Auth.Models.Request;

namespace Api.Auth.Service.Interface
{
    public interface ITokenService
    {
        string GetToken(AuthRequest tokenRequest);
        string RefreshToken(RefreshAuthRequest refreshTokenRequest);
    }
}
