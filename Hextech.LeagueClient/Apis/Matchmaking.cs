using Hextech.LeagueClient.Models.Matchmaking;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Apis
{
    public class Matchmaking : ApiBase
    {
        public override string Name => "lol-matchmaking";

        public Matchmaking(LeagueHttpClient client) : base(client)
        {

        }

        public async Task<ReadyCheck> GetReadyCheck()
        {
            return await m_client.GetAsync<ReadyCheck>(GetUrl("/v1/ready-check"));
        }
    }
}
