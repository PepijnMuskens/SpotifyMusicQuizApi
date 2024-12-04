namespace SpotifyMusicQuizApi.Models
{
    public class Song
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Artist> Artists { get; set; }
        
    }
}
