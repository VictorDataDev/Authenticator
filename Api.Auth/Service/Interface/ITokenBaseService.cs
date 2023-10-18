using Api.Auth.Models;

namespace Api.Auth.Service.Interface
{
    public interface ITokenBaseService
    {
        string GetToken();
        string RefreshToken(string oldToken);
    }
}
