using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotifyMusicQuizApi.Models;
using RestSharp;
using System.Text.Json;
using Newtonsoft.Json;

namespace SpotifyMusicQuizApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        [HttpGet("GetPlaybackDevices")]
        public IEnumerable<Device> GetPlaybackDevices(string token)
        {
            var client = new RestClient("https://api.spotify.com/v1");
            var request = new RestRequest($"me/player/devices");
            request.AddHeader("Authorization", $"Bearer {token}");

            var response = client.Get(request);
            var content = response.Content;

            List<Device> devices = JsonConvert.DeserializeObject<List<Device>>(JsonDocument.Parse(content).RootElement.GetProperty("devices").ToString());
            
            return devices;
        }
    }
}
