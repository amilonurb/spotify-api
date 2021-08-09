using Microsoft.Extensions.Options;
using SpotifyWebAPI.Application.Services.Common;
using SpotifyWebAPI.Application.Services.Token.Get;
using SpotifyWebAPI.Services.HttpClients.Spotify;
using SpotifyWebAPI.Shared.Context;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SpotifyWebAPI.Services.Token.Get
{
    public class GetTokenService : IGetTokenService
    {
        private readonly IMyHttpContextAccessor _context;
        private readonly IHttpClient<SpotifyHttpClient> _httpClient;
        private readonly SpotifyOptions _options;

        public GetTokenService(IMyHttpContextAccessor context,
                               IHttpClient<SpotifyHttpClient> httpClient,
                               IOptionsMonitor<SpotifyOptions> options)
        {
            _context = context;
            _httpClient = httpClient;
            _options = options.CurrentValue;
        }

        public async Task<GetTokenServiceDto> ExecuteAsync(string userCode)
        {
            var url = $"{_options.BaseUrlAuth}{_options.Resources.Authorization.Uri}";

            var redirectUri = $"{_context.GetCurrentBaseUrl()}{_options.RedirectUri}";

            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "grant_type", _options.Resources.Authorization.GrantType },
                    { "code", userCode },
                    { "redirect_uri", redirectUri }
                })
            };

            var authCode = $"{_options.ClientID}:{_options.ClientSecret}";

            var encodedAuthCode = Convert.ToBase64String(Encoding.Default.GetBytes(authCode));

            request.Headers.Add("Authorization", $"{_options.Resources.Authorization.TokenType} {encodedAuthCode}");

            var response = await _httpClient.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<GetTokenServiceDto>(content);
        }
    }
}