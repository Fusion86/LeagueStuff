using Hextech.LeagueClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hextech.LeagueClient
{
    public class System
    {
        private LeagueClient m_client;

        public System(LeagueClient client)
        {
            m_client = client;
        }

        public async Task<BuildInfo> GetBuildInfo()
        {
            string str = await m_client.GetAsync("/system/v1/builds");
            BuildInfo buildInfo = JsonConvert.DeserializeObject<BuildInfo>(str);
            return buildInfo;
        }
    }
}
