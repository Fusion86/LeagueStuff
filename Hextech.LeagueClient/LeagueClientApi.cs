using Hextech.LeagueClient.Apis;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Threading.Tasks;

namespace Hextech.LeagueClient
{
    public class LeagueClientApi
    {
        public readonly LeagueHttpClient HttpClient;

        public readonly AssetsApi Assets;
        public readonly ChatApi Chat;
        public readonly DataStoreApi DataStore;
        public readonly GameDataApi GameData;
        public readonly InventoryApi Inventory;
        public readonly LoginApi Login;
        public readonly MatchmakingApi Matchmaking;
        public readonly MissionsApi Missions;
        public readonly PerformanceApi Performance;
        public readonly PerksApi Perks;
        public readonly PlayerBehaviorApi PlayerBehavior;
        public readonly RiotClientApi RiotClient;
        public readonly SummonerApi Summoner;
        public readonly SystemApi System;

        public bool IsConnected { get; private set; }

        public LeagueClientApi()
        {
            HttpClient = new LeagueHttpClient();

            Assets = new AssetsApi(HttpClient);
            Chat = new ChatApi(HttpClient);
            DataStore = new DataStoreApi(HttpClient);
            GameData = new GameDataApi(HttpClient);
            Inventory = new InventoryApi(HttpClient);
            Login = new LoginApi(HttpClient);
            Matchmaking = new MatchmakingApi(HttpClient);
            Missions = new MissionsApi(HttpClient);
            Performance = new PerformanceApi(HttpClient);
            Perks = new PerksApi(HttpClient);
            PlayerBehavior = new PlayerBehaviorApi(HttpClient);
            RiotClient = new RiotClientApi(HttpClient);
            Summoner = new SummonerApi(HttpClient);
            System = new SystemApi(HttpClient);
        }

        public async Task<bool> Initialize()
        {
            PasswordPort pp = Utility.GetPasswordPort();
            if (pp == null) return false;
            return IsConnected = await HttpClient.Login(pp.Password, pp.Port);
        }

        public static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy
                {
                    OverrideSpecifiedNames = false
                }
            },
            Formatting = Formatting.Indented // Probably negligible performance impact and it makes debugging more enjoyable
        };
    }
}
