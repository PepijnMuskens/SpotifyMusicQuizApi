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

        
        [HttpGet(Name = "GetToken")]
        public string GetToken()
        {
            return Token.GetToken();
        }
    }
}
