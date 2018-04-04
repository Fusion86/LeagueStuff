using Hextech.LeagueClient.Models.System;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Apis
{
    public class SystemApi : ApiBase
    {
        public SystemApi(LeagueHttpClient client) : base(client)
        {

        }

        public async Task<BuildInfo> GetBuildInfo()
        {
            string str = await m_client.GetAsync("/system/v1/builds");
            var obj = JsonConvert.DeserializeObject<BuildInfo>(str);
            return obj;
        }
    }
}
