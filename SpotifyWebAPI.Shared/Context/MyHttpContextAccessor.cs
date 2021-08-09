using Microsoft.AspNetCore.Http;

namespace SpotifyWebAPI.Shared.Context
{
    public class MyHttpContextAccessor : IMyHttpContextAccessor
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public MyHttpContextAccessor(IHttpContextAccessor contextAccessor) => _contextAccessor = contextAccessor;

        public string GetCurrentBaseUrl()
        {
            var scheme = _contextAccessor.HttpContext.Request.Scheme;

            var host = _contextAccessor.HttpContext.Request.Host;

            return $"{scheme}://{host}";
        }
    }
}