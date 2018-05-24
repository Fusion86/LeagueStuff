using Hextech.LeagueClient.Models.GameData;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Apis
{
    public class GameDataApi : ApiBase
    {
        public override string Name => "lol-game-data";

        public GameDataApi(LeagueHttpClient client) : base(client)
        {

        }

        public async Task<List<Champion>> GetChampionSummary()
        {
            return await m_client.GetAsync<List<Champion>>(GetPluginUrl("/assets/v1/champion-summary.json"));
        }
    }
}
