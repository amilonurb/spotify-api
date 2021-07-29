using Microsoft.AspNetCore.Mvc;
using SpotifyWebAPI.Application.Services.Token.Get;
using System.Threading.Tasks;

namespace SpotifyWebAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IGetTokenService _getTokenService;

        public AuthController(IGetTokenService getTokenService) => _getTokenService = getTokenService;

        [HttpPost("token")]
        public async Task<IActionResult> GetToken(string userCode) =>
            Ok(await _getTokenService.ExecuteAsync(userCode));
    }
}