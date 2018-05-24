using Hextech.LeagueClient.Models.Chat;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Apis
{
    public class ChatApi : ApiBase
    {
        public override string Name => "lol-chat";

        public ChatApi(LeagueHttpClient client) : base(client)
        {
        }

        public async Task<ChatServiceDynamicClientConfig> GetConfig()
        {
            return await m_client.GetAsync<ChatServiceDynamicClientConfig>(GetPluginUrl("/v1/config"));
        }

        public async Task<List<FriendResource>> GetFriends()
        {
            return await m_client.GetAsync<List<FriendResource>>(GetPluginUrl("/v1/friends"));
        }

        public async Task<FriendResource> GetMe()
        {
            return await m_client.GetAsync<FriendResource>(GetPluginUrl("/v1/me"));
        }
    }
}
