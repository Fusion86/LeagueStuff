using System.Net.Http;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Apis
{
    public class AssetsApi : ApiBase
    {
        public override string Name => "system";

        public AssetsApi(LeagueHttpClient client) : base(client)
        {
        }

        public async Task<byte[]> GetAsset(string path)
        {
            HttpResponseMessage res = await m_client.GetAsync(path);

            if (res.IsSuccessStatusCode) return await res.Content.ReadAsByteArrayAsync();
            else return null;
        }

        public async Task<byte[]> GetAsset(ApiBase plugin, string path)
        {
            HttpResponseMessage res = await m_client.GetAsync($"/{plugin.Name}/assets{path}");

            if (res.IsSuccessStatusCode) return await res.Content.ReadAsByteArrayAsync();
            else return null;
        }
    }
}
