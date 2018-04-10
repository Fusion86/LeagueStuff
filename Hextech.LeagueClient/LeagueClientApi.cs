using Hextech.LeagueClient.Apis;
using System;
using System.Threading.Tasks;

namespace Hextech.LeagueClient
{
    public class LeagueClientApi
    {
        private LeagueHttpClient client;

        public SystemApi System;
        public ChatApi Chat;
        public SummonerApi Summoner;

        public bool IsLoggedIn { get; private set; }

        public event EventHandler OnLoggedIn;
        public event EventHandler OnLoggedOut;

        public LeagueClientApi()
        {
            client = new LeagueHttpClient();

            System = new SystemApi(client);
            Chat = new ChatApi(client);
            Summoner = new SummonerApi(client);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="port"></param>
        /// <returns>True if login successful, false on error or when already logged in</returns>
        public async Task<bool> Login(string password, int port)
        {
            if (IsLoggedIn) return false;

            IsLoggedIn = await client.Login(password, port);

            if (IsLoggedIn)
                OnLoggedIn(this, EventArgs.Empty);

            return IsLoggedIn;
        }
    }
}
