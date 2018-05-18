using Hextech.LeagueClient.Apis;
using System.Threading.Tasks;

namespace Hextech.LeagueClient
{
    public class LeagueClientApi
    {
        public LeagueHttpClient HttpClient { get; private set; }

        public AssetsApi Assets;
        public SystemApi System;
        public ChatApi Chat;
        public SummonerApi Summoner;
        public GameDataApi GameData;

        public bool IsConnected { get; private set; }

        public LeagueClientApi()
        {
            HttpClient = new LeagueHttpClient();

            Assets = new AssetsApi(HttpClient);
            System = new SystemApi(HttpClient);
            Chat = new ChatApi(HttpClient);
            Summoner = new SummonerApi(HttpClient);
            GameData = new GameDataApi(HttpClient);
        }

        public async Task<bool> Initialize()
        {
            PasswordPort pp = Utility.GetPasswordPort();
            if (pp == null) return false;
            return IsConnected = await HttpClient.Login(pp.Password, pp.Port);
        }
    }
}
