using Hextech.LeagueClient.Models.Summoner;
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
            return await m_client.GetAsync<Summoner>(GetPluginUrl("/v1/current-summoner"));
        }

        public async Task<Summoner> GetSummoner(string name)
        {
            return await m_client.GetAsync<Summoner>(GetPluginUrl("/v1/summoners?name=" + HttpUtility.UrlEncode(name)));
        }
    }
}
