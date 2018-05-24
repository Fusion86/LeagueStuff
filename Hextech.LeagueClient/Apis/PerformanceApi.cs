using Hextech.LeagueClient.Models.Performance;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Apis
{
    public class PerformanceApi : ApiBase
    {
        public override string Name => "performance";

        public PerformanceApi(LeagueHttpClient client) : base(client)
        {
        }

        /// <summary>
        /// Returns process memory status
        /// </summary>
        /// <returns></returns>
        public async Task<MemoryStatus> GetMemoryStatus()
        {
            return await m_client.GetAsync<MemoryStatus>(GetPluginUrl("/v1/memory"));
        }

        /// <summary>
        /// Returns the various performance information for the cef processes
        /// </summary>
        /// <returns></returns>
        public async Task<List<MemoryStatus>> GetCefReport()
        {
            return await m_client.GetAsync<List<MemoryStatus>>(GetPluginUrl("/v1/report"));
        }

        /// <summary>
        /// Returns hardware and software specs for the machine the client is running on.
        /// </summary>
        /// <returns></returns>
        public async Task<SystemInfo> GetSystemInfo()
        {
            return await m_client.GetAsync<SystemInfo>(GetPluginUrl("/v1/system-info"));
        }
    }
}
