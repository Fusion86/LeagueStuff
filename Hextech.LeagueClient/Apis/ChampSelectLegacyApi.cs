using Hextech.LeagueClient.Models.ChampSelectLegacy;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Apis
{
    public class ChampSelectLegacy : ApiBase
    {
        public override string Name => "lol-champ-select-legacy";

        public ChampSelectLegacy(LeagueHttpClient client) : base(client)
        {
        }

        public async Task<ChampSelectSession> GetSession()
        {
            return await m_client.GetAsync<ChampSelectSession>(GetPluginUrl("/v1/session"));
        }
    }
}
