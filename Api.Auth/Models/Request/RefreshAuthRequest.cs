namespace Api.Auth.Models.Request
{
    public class RefreshAuthRequest
    {
        public string OldToken { get; set; }

        public int ParametersForToken { set; get; }
    }
}
