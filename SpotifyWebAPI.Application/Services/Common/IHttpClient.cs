using System.Net.Http;
using System.Threading.Tasks;

namespace SpotifyWebAPI.Application.Services.Common
{
    public interface IHttpClient<T>
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    }
}