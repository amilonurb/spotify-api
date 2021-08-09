namespace SpotifyWebAPI.Application.Services.Common
{
    public class AuthorizationResource
    {
        public string GrantType { get; set; }
        public string TokenType { get; set; }
        public string Uri { get; set; }
    }
}