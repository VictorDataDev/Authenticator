namespace Api.Auth.Models.Response
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public string Trace { get; set; } = Guid.NewGuid().ToString();
    }
}
