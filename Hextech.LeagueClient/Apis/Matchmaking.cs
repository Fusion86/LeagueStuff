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

        public async Task AcceptReadyCheck()
        {
            await m_client.PostAsync(GetUrl("/v1/ready-check/accept"));
        }

        public async Task DeclineReadyCheck()
        {
            await m_client.PostAsync(GetUrl("/v1/ready-check/decline"));
        }

        public async Task<SearchResource> GetSearchData()
        {
            return await m_client.GetAsync<SearchResource>(GetUrl("/v1/search"));
        }
    }
}
