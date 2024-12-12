using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
namespace SpotifyMusicQuizApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> _logger;

        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
        }


        [HttpGet("CreateGame")]

        public string CreateGame(string token)
        {
            return GameManager.CreateLobby(token).ToString();
        }

        [HttpPut("JoinGame/{code}/{name}/{id}")]
        public bool JoinGame(string code, string name, string id)
        {
            try
            {
                int codeint = Convert.ToInt16(code);
                return GameManager.JoinLobby(codeint, name, id);
            }
            catch(Exception e)
            {
                return false;
            }
            
        }

        [HttpGet("GetGame/{code}")]
        public string GetGame(string code)
        {
            try
            {
                int codeint = Convert.ToInt16(code);
                return JsonSerializer.Serialize(GameManager.GetLobby(codeint));
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPut("ToggleOpen/{code}/{playerid}/{value}")]
        public bool ToggleOpen(string code, string playerid, bool value)
        {
            try
            {
                int codeint = Convert.ToInt16(code);
                Lobby lobby = GameManager.GetLobby(codeint);
                return lobby.SetStatus(playerid, value);

            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
