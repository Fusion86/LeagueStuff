using Hextech.LeagueClient.Models.Missions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Apis
{
    public class MissionsApi : ApiBase
    {
        public override string Name => "lol-missions";

        public MissionsApi(LeagueHttpClient client) : base(client)
        {

        }

        public async Task<List<PlayerMission>> GetMissions()
        {
            return await m_client.GetAsync<List<PlayerMission>>(GetUrl("/v1/missions"));
        }

        public async Task<List<MissionSeries>> GetSeries()
        {
            return await m_client.GetAsync<List<MissionSeries>>(GetUrl("/v1/series"));
        }
    }
}
