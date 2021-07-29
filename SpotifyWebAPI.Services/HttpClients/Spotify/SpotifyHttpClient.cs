using SpotifyWebAPI.Application.Services.Common;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpotifyWebAPI.Services.HttpClients.Spotify
{
    public class SpotifyHttpClient : IHttpClient<SpotifyHttpClient>
    {
        private readonly HttpClient _httpClient;

        public SpotifyHttpClient(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request) => await _httpClient.SendAsync(request);
    }
}