using Microsoft.AspNetCore.Mvc;
using SpotifyWebAPI.Application.Services.Token.Get;
using System.Threading.Tasks;

namespace SpotifyWebAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IGetTokenService _getTokenService;

        public AuthController(IGetTokenService getTokenService) => _getTokenService = getTokenService;

        /// <summary>
        /// Retorna um token de usuário
        /// </summary>
        /// <param name="userCode">Código obtido após a autorização do usuário</param>
        /// <remarks>
        /// Como obter o código do usuário: https://developer.spotify.com/documentation/general/guides/authorization-guide/
        /// </remarks>
        [HttpPost("token")]
        public async Task<IActionResult> GetToken([FromBody] string userCode) =>
            Ok(await _getTokenService.ExecuteAsync(userCode));

        [HttpGet("callback")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult AuthCallback([FromQuery] string code, [FromQuery] string state, [FromQuery] string error)
        {
            if (error is not null)
            {
                return BadRequest(new { state, error });
            }

            return Ok(new { code, state });
        }
    }
}