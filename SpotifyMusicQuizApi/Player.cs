using System.Globalization;

namespace SpotifyMusicQuizApi
{
    public class Player
    {
        public string Name { get; set; }
        public string Id { get; set; }

        public Player(string name, string id)
        {
            Name = name;
            Id = id;
        }

    }
}
