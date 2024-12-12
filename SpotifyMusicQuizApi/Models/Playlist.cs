namespace SpotifyMusicQuizApi.Models
{
    public class Playlist
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Song> Songs { get; set; }
        public string Img { get; set; }

        public Playlist(string id, string name, string img)
        {
            Id = id;
            Name = name;
            Songs = new List<Song>();
            Img = img;
        }
    }
}
