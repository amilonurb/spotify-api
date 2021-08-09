namespace SpotifyWebAPI.Application.Services.Common
{
    public class SpotifyOptions
    {
        public string BaseUrlAuth { get; set; }
        public string BaseUrlAPI { get; set; }
        public string ClientID { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectUri { get; set; }
        public SpotifyResources Resources { get; set; }
    }
}