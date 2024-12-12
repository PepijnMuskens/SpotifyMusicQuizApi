using Microsoft.AspNetCore.Mvc;
namespace SpotifyMusicQuizApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private readonly ILogger<AuthorizationController> _logger;

        public AuthorizationController(ILogger<AuthorizationController> logger)
        {
            _logger = logger;
        }


        [HttpGet("GetToken")]

        public string GetToken()
        {
            return Token.GetToken();
        }

        [HttpGet("GetTokencode/{code}")]
        public string GetTokenCode(string code)
        {
            return Token.GetTokenCode(code);
        }
    }
}
