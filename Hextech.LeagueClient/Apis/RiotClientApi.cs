using Hextech.LeagueClient.Models.RiotClient;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Apis
{
    public class RiotClientApi : ApiBase
    {
        public override string Name => "riotclient";

        public RiotClientApi(LeagueHttpClient client) : base(client)
        {
        }

        public async Task<BasicSystemInfo> GetInstallDir()
        {
            return await m_client.GetAsync<BasicSystemInfo>(GetPluginUrl("/system-info/v1/basic-info"));
        }

        public async Task<string> GetUxState()
        {
            var res = await m_client.GetAsync(GetPluginUrl("/ux-state"));
            var str = await res.Content.ReadAsStringAsync();
            return str.Substring(1, str.Length - 2); // Remove start and end quotes
        }

        public async Task ShowUx()
        {
            await m_client.PostAsync(GetPluginUrl("/ux-show"));
        }

        public async Task MinimizeUx()
        {
            await m_client.PostAsync(GetPluginUrl("/ux-minimize"));
        }

        public async Task FlashUx()
        {
            await m_client.PostAsync(GetPluginUrl("/ux-flash"));
        }
    }
}
