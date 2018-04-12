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
            string str = await m_client.GetAsync(GetUrl("/assets/v1/champion-summary.json"));
            var obj = JsonConvert.DeserializeObject<List<Champion>>(str);
            return obj;
        }
    }
}
