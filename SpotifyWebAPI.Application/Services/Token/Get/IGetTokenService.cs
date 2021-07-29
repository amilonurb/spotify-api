using System.Threading.Tasks;

namespace SpotifyWebAPI.Application.Services.Token.Get
{
    public interface IGetTokenService
    {
        Task<GetTokenServiceDto> ExecuteAsync(string userCode);
    }
}