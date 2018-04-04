using Hextech.LeagueClient.Models.Chat;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Apis
{
    public class ChatApi : ApiBase
    {
        public ChatApi(LeagueHttpClient client) : base(client)
        {

        }

        public async Task<ChatServiceDynamicClientConfig> GetConfig()
        {
            string str = await m_client.GetAsync("/lol-chat/v1/config");
            var obj = JsonConvert.DeserializeObject<ChatServiceDynamicClientConfig>(str);
            return obj;
        }

        public async Task<List<FriendResource>> GetFriends()
        {
            string str = await m_client.GetAsync("/lol-chat/v1/friends");
            var obj = JsonConvert.DeserializeObject<List<FriendResource>>(str);
            return obj;
        }

        public async Task<FriendResource> GetMe()
        {
            string str = await m_client.GetAsync("/lol-chat/v1/me");
            var obj = JsonConvert.DeserializeObject<FriendResource>(str);
            return obj;
        }
    }
}
