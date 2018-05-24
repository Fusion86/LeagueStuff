using System.Threading.Tasks;

namespace Hextech.LeagueClient.Apis
{
    public class DataStoreApi : ApiBase
    {
        public override string Name => "data-store";

        public DataStoreApi(LeagueHttpClient client) : base(client)
        {
        }

        public async Task<string> GetInstallDir()
        {
            var res = await m_client.GetAsync(GetPluginUrl("/v1/install-dir"));
            string str = await res.Content.ReadAsStringAsync();
            return str.Substring(1, str.Length - 2); // Remove start and end quotes, e.g "C:\Install Dir" becomes C:\Install Dir
        }
    }
}
