using Hextech.LeagueClient.Models.Summoner;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web;

namespace Hextech.LeagueClient.Apis
{
    public class SummonerApi : ApiBase
    {
        public override string Name => "lol-summoner";

        public SummonerApi(LeagueHttpClient client) : base(client)
        {

        }

        public async Task<Summoner> GetCurrentSummoner()
        {
            string str = await m_client.GetAsync(GetUrl("/v1/current-summoner"));
            var obj = JsonConvert.DeserializeObject<Summoner>(str);
            return obj;
        }

        public async Task<Summoner> GetSummoner(string name)
        {
            string str = await m_client.GetAsync(GetUrl("/v1/summoners?name=" + HttpUtility.UrlEncode(name)));
            var obj = JsonConvert.DeserializeObject<Summoner>(str);
            return obj;
        }
    }
}
