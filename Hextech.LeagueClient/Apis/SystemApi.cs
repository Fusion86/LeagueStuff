using Hextech.LeagueClient.Models.System;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Apis
{
    public class SystemApi : ApiBase
    {
        public override string Name => "system";

        public SystemApi(LeagueHttpClient client) : base(client)
        {

        }

        public async Task<BuildInfo> GetBuildInfo()
        {
            return await m_client.GetAsync<BuildInfo>(GetUrl("/v1/builds"));
        }
    }
}
