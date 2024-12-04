namespace SpotifyMusicQuizApi.Models
{
    public class Playlist
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Song> Songs { get; set; }

        public Playlist(string id, string name)
        {
            Id = id;
            Name = name;
            Songs = new List<Song>();
        }
    }
}
