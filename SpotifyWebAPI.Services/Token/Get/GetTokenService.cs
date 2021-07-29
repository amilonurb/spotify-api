using SpotifyWebAPI.Application.Services.Token.Get;
using System;
using System.Threading.Tasks;

namespace SpotifyWebAPI.Services.Token.Get
{
    public class GetTokenService : IGetTokenService
    {
        public Task<GetTokenServiceDto> ExecuteAsync(string userCode)
        {
            throw new NotImplementedException("TESTE");
        }
    }
}