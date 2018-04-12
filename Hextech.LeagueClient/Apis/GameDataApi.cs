using System.Threading.Tasks;

namespace Hextech.LeagueClient.Apis
{
    public class GameDataApi : ApiBase
    {
        public override string Name => "lol-game-data";

        public GameDataApi(LeagueHttpClient client) : base(client)
        {

        }

        public async Task<object[]> GetChampionSummary()
        {
            string str = await m_client.GetAsync(GetUrl("/assets/v1/champion-summary.json"));

            return new object[] { };
        }
    }
}
