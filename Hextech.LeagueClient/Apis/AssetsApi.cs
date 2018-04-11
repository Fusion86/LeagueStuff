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
            return await m_client.GetByteArrayAsync(path);
        }

        public async Task<byte[]> GetAsset(ApiBase plugin, string path)
        {
            return await m_client.GetByteArrayAsync($"/{plugin.Name}/assets{path}");         
        }
    }
}
