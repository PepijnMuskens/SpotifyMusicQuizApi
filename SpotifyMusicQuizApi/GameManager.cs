using System.Text.Json;

namespace SpotifyMusicQuizApi
{
    public static class GameManager
    {
        private static List<Lobby> lobbies = new List<Lobby>();

        public static int CreateLobby(string token)
        {
            Random rnd = new Random();
            int id = rnd.Next(1000, 9999);
            while(lobbies.Find(l => l.Id == id) != null)
            {
                id = rnd.Next(1000, 9999);
            }
            Lobby lobby = new Lobby(id,token);
            lobbies.Add(lobby);
            return id;
        }

        public static bool JoinLobby(int id, string playername, string playerid)
        {
            Lobby lobby = lobbies.Find(l => l.Id == id);
            if(lobby != null)
            {
                return lobby.Join(new Player(playername, playerid));
            }
            else
            {
                return false;
            }
            
        }

        public static Lobby GetLobby(int id)
        {
            return lobbies.Find(l => l.Id == id);
        }
    }
}
