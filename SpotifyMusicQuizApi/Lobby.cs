using System.Threading.Channels;

namespace SpotifyMusicQuizApi
{
    public class Lobby
    {
        public int Id { get; set; }
        public List<Player> players { get; set; }
        public bool Status { get; set; }

        public string token { get; set; }

        public Lobby(int id, string token)
        {
            Id = id;
            players = new List<Player>();
            Status = true;
            this.token = token;
        }

        public bool Join(Player player)
        {
            if(players.Find(p => p.Name == player.Name || p.Id == player.Id) != null || Status == false){
                return false;
            }
            players.Add(player);
            if (players.Count == 1) Status = false;
            return true;
        }

        public bool SetStatus(string playerid, bool status)
        {
            if(playerid == players[0].Id)
            {
                Status = status;
                return true;
            }
            return false;
            
        }
    }
}
