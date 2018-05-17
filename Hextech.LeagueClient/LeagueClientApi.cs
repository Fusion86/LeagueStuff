using Hextech.LeagueClient.Apis;
using System;
using System.Threading.Tasks;

namespace Hextech.LeagueClient
{
    public class LeagueClientApi
    {
        private LeagueHttpClient client;

        public AssetsApi Assets;
        public SystemApi System;
        public ChatApi Chat;
        public SummonerApi Summoner;
        public GameDataApi GameData;

        public bool IsConnected { get; private set; }

        public LeagueClientApi()
        {
            client = new LeagueHttpClient();

            Assets = new AssetsApi(client);
            System = new SystemApi(client);
            Chat = new ChatApi(client);
            Summoner = new SummonerApi(client);
            GameData = new GameDataApi(client);
        }

        public async Task<bool> Initialize()
        {
            PasswordPort pp = Utility.GetPasswordPort();
            if (pp == null) return false;
            return IsConnected = await client.Login(pp.Password, pp.Port);
        }
    }
}
