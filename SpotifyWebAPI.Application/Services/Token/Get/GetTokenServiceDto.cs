using System.Text.Json.Serialization;

namespace SpotifyWebAPI.Application.Services.Token.Get
{
    public class GetTokenServiceDto
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("access_token")]
        public string TokenType { get; set; }

        [JsonPropertyName("access_token")]
        public string ExpiresIn { get; set; }

        [JsonPropertyName("access_token")]
        public string RefreshToken { get; set; }
    }
}