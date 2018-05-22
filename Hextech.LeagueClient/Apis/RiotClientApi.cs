using System.Threading.Tasks;
using Hextech.LeagueClient.Models.RiotClient;

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
            return await m_client.GetAsync<BasicSystemInfo>(GetUrl("/system-info/v1/basic-info"));
        }

        public async Task<string> GetUxState()
        {
            var res = await m_client.GetAsync(GetUrl("/ux-state"));
            var str = await res.Content.ReadAsStringAsync();
            return str.Substring(1, str.Length - 2); // Remove start and end quotes
        }

        public async Task ShowUx()
        {
            await m_client.PostAsync(GetUrl("/ux-show"));
        }

        public async Task MinimizeUx()
        {
            await m_client.PostAsync(GetUrl("/ux-minimize"));
        }

        public async Task FlashUx()
        {
            await m_client.PostAsync(GetUrl("/ux-flash"));
        }
    }
}
