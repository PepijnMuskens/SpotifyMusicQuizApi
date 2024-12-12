using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotifyMusicQuizApi.Models;
using RestSharp;
using System.Text.Json;

namespace SpotifyMusicQuizApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserdataController : ControllerBase
    {
        [HttpGet("GetPlaylist")]
        public IEnumerable<Playlist> GetPlaylists(string userid)
        {
            var client = new RestClient("https://api.spotify.com/v1");
            var request = new RestRequest($"users/{userid}/playlists");
            request.AddHeader("Authorization", $"Bearer {Token.GetToken()}");
            
            var response = client.Get(request);
            var content = response.Content;
            
            
            int total = Convert.ToInt32(JsonDocument.Parse(content).RootElement.GetProperty("total").ToString());
            List<Playlist> list = new List<Playlist>();
            for (int i = 0; i < total; i++)
            {
                string id = JsonDocument.Parse(content).RootElement.GetProperty("items")[i].GetProperty("id").ToString();
                string name = JsonDocument.Parse(content).RootElement.GetProperty("items")[i].GetProperty("name").ToString();
                string img = JsonDocument.Parse(content).RootElement.GetProperty("items")[i].GetProperty("images")[0].GetProperty("url").ToString();
                list.Add(new Playlist(id, name, img));
            }
            return list;
        }
    }
}
