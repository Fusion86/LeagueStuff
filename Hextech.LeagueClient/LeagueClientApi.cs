using Hextech.LeagueClient.Apis;
using System.Threading.Tasks;

namespace Hextech.LeagueClient
{
    public class LeagueClientApi
    {
        public LeagueHttpClient HttpClient { get; private set; }

        public AssetsApi Assets;
        public ChatApi Chat;
        public GameDataApi GameData;
        public Matchmaking Matchmaking;
        public SummonerApi Summoner;
        public SystemApi System;

        public bool IsConnected { get; private set; }

        public LeagueClientApi()
        {
            HttpClient = new LeagueHttpClient();

            Assets = new AssetsApi(HttpClient);
            Chat = new ChatApi(HttpClient);
            GameData = new GameDataApi(HttpClient);
            Matchmaking = new Matchmaking(HttpClient);
            Summoner = new SummonerApi(HttpClient);
            System = new SystemApi(HttpClient);
        }

        public async Task<bool> Initialize()
        {
            PasswordPort pp = Utility.GetPasswordPort();
            if (pp == null) return false;
            return IsConnected = await HttpClient.Login(pp.Password, pp.Port);
        }
    }
}
