using Microsoft.AspNetCore.SignalR;
using RestSharp;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;

namespace SpotifyMusicQuizApi
{
    public static class Token
    {
        private static string token = "";
        private static DateTime expireTime = DateTime.UtcNow;

        private static string clientId;
        private static string clientSecret;

        static Token()
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();

            clientId = config["CLIENT_ID"];
            clientSecret = config["CLIENT_SECRET"];

            if (clientId == null) clientId = "";
            if (clientSecret == null) clientSecret = "";
        }

        public static string GetToken()
        {
            if (expireTime < DateTime.UtcNow) {
                var client  = new RestClient("https://accounts.spotify.com");
                var request = new RestRequest("api/token");
                request.AddParameter("grant_type", "client_credentials");
                request.AddParameter("client_id", clientId);
                request.AddParameter("client_secret", clientSecret);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                var response = client.Post(request);
                var content = response.Content;
                if (content != null)
                {

                    token = JsonDocument.Parse(content).RootElement.GetProperty("access_token").ToString();
                    string time = JsonDocument.Parse(content).RootElement.GetProperty("expires_in").ToString(); ;
                    expireTime = DateTime.UtcNow.AddSeconds(Convert.ToInt32(time));
                }

                return token;
            }
            return token;
        }

        public static string GetTokenCode(string code)
        {
            if (expireTime < DateTime.UtcNow)
            {
                var client = new RestClient("https://accounts.spotify.com");
                var request = new RestRequest("api/token");
                request.AddParameter("grant_type", "authorization_code");
                request.AddParameter("redirect_uri", "http://127.0.0.1:5173");
                request.AddParameter("code", code);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddHeader("Authorization", $"Basic {clientId}:{clientSecret}");
                var response = client.Post(request);
                var content = response.Content;
                if (content != null)
                {
                    token = JsonDocument.Parse(content).RootElement.GetProperty("access_token").ToString();
                    string time = JsonDocument.Parse(content).RootElement.GetProperty("expires_in").ToString(); ;
                    expireTime = DateTime.UtcNow.AddSeconds(Convert.ToInt32(time));
                }

                return token;
            }
            return token;
        }
    }
}
