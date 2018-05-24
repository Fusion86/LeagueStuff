using Hextech.LeagueClient.Models.Login;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Apis
{
    public class LoginApi : ApiBase
    {
        public override string Name => "lol-login";

        public LoginApi(LeagueHttpClient client) : base(client)
        {
        }

        public async Task<LoginSession> GetSession()
        {
            return await m_client.GetAsync<LoginSession>(GetPluginUrl("/v1/session"));
        }

        public async Task<Wallet> GetWallet()
        {
            return await m_client.GetAsync<Wallet>(GetPluginUrl("/v1/wallet"));
        }

        public async Task<PlatformGeneratedCredentials> GetPlatformCredentials()
        {
            return await m_client.GetAsync<PlatformGeneratedCredentials>(GetPluginUrl("/v1/login-platform-credentials"));
        }
    }
}
