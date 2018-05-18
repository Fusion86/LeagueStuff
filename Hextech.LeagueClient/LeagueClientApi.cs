using Hextech.LeagueClient.Apis;
using System.Threading.Tasks;

namespace Hextech.LeagueClient
{
    public class LeagueClientApi
    {
        public readonly LeagueHttpClient HttpClient;

        public readonly AssetsApi Assets;
        public readonly ChatApi Chat;
        public readonly GameDataApi GameData;
        public readonly Matchmaking Matchmaking;
        public readonly Missions Missions;
        public readonly SummonerApi Summoner;
        public readonly SystemApi System;

        public bool IsConnected { get; private set; }

        public LeagueClientApi()
        {
            HttpClient = new LeagueHttpClient();

            Assets = new AssetsApi(HttpClient);
            Chat = new ChatApi(HttpClient);
            GameData = new GameDataApi(HttpClient);
            Matchmaking = new Matchmaking(HttpClient);
            Missions = new Missions(HttpClient);
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
