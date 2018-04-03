using Newtonsoft.Json;

namespace Hextech.LeagueClient.Models.Chat
{
    public class ChatServiceDynamicClientConfig
    {
        [JsonProperty("ChatDomain", Required = Required.Always)]
        public LolChatChatDomainConfig ChatDomain { get; set; }

        [JsonProperty("LcuSocial", Required = Required.Always)]
        public LolChatLcuSocialConfig LcuSocial { get; set; }
    }

    public class LolChatChatDomainConfig
    {
        [JsonProperty("ChampSelectDomainName", Required = Required.Always)]
        public string ChampSelectDomainName { get; set; }

        [JsonProperty("ClubDomainName")]
        public string ClubDomainName { get; set; }

        [JsonProperty("CustomGameDomainName")]
        public string CustomGameDomainName { get; set; }

        [JsonProperty("CustomTeamDomainName")]
        public string CustomTeamDomainName { get; set; }

        [JsonProperty("P2PDomainName")]
        public string P2PDomainName { get; set; }

        [JsonProperty("PostGameDomainName")]
        public string PostGameDomainName { get; set; }

        [JsonProperty("PrivateDomainName")]
        public string PrivateDomainName { get; set; }

        [JsonProperty("PublicDomainName")]
        public string PublicDomainName { get; set; }

        [JsonProperty("RankedTeamDomainName")]
        public string RankedTeamDomainName { get; set; }

        [JsonProperty("TeamBuilderDomainName")]
        public string TeamBuilderDomainName { get; set; }
    }

    public class LolChatLcuSocialConfig
    {
        [JsonProperty("AggressiveScanning", Required = Required.Always)]
        public bool AggressiveScanning { get; set; }

        [JsonProperty("ForceChatFilter")]
        public bool ForceChatFilter { get; set; }

        [JsonProperty("QueueJobGraceSeconds")]
        public long QueueJobGraceSeconds { get; set; }

        [JsonProperty("SilenceChatWhileInGame")]
        public bool SilenceChatWhileInGame { get; set; }
    }
}
