using Microsoft.AspNetCore.Mvc;

namespace SpotifyMusicQuizApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private string token;
        private DateTime expireTime;

        private readonly ILogger<AuthorizationController> _logger;

        public AuthorizationController(ILogger<AuthorizationController> logger)
        {
            _logger = logger;
            token = "";
        }

        [HttpGet(Name = "GetToken")]
        public string Get()
        {

            return token;
        }
    }
}
