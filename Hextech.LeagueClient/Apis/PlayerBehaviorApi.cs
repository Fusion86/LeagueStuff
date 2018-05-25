using Hextech.LeagueClient.Models.PlayerBehavior;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hextech.LeagueClient.Apis
{
    public class PlayerBehaviorApi : ApiBase
    {
        public override string Name => "lol-player-behavior";

        public PlayerBehaviorApi(LeagueHttpClient client) : base(client)
        {
        }

        public async Task<BanNotification> GetBan()
        {
            return await m_client.GetAsync<BanNotification>(GetPluginUrl("/v1/ban"));
        }

        public async Task<RestrictionNotification> GetChatRestriction()
        {
            return await m_client.GetAsync<RestrictionNotification>(GetPluginUrl("/v1/chat-restriction"));
        }

        public async Task<RestrictionNotification> GetRankedRestriction()
        {
            return await m_client.GetAsync<RestrictionNotification>(GetPluginUrl("/v1/ranked-restriction"));
        }

        public async Task<PlayerBehaviorConfig> GetConfig()
        {
            return await m_client.GetAsync<PlayerBehaviorConfig>(GetPluginUrl("/v1/config"));
        }

        public async Task<ReformCard> GetReformCard()
        {
            return await m_client.GetAsync<ReformCard>(GetPluginUrl("/v1/reform-card"));
        }

        public async Task<List<ReporterFeedback>> GetReporterFeedback()
        {
            return await m_client.GetAsync<List<ReporterFeedback>>(GetPluginUrl("/v1/reporter-feedback"));
        }
    }
}
