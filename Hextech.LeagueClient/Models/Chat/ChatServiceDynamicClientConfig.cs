namespace Hextech.LeagueClient.Models.Chat
{
    public class ChatServiceDynamicClientConfig
    {
        public ChatDomainConfig ChatDomain { get; set; }
        public ChatLcuSocialConfig LcuSocial { get; set; }
    }

    public class ChatDomainConfig
    {
        public string ChampSelectDomainName { get; set; }
        public string ClubDomainName { get; set; }
        public string CustomGameDomainName { get; set; }
        public string CustomTeamDomainName { get; set; }
        public string P2PDomainName { get; set; }
        public string PostGameDomainName { get; set; }
        public string PrivateDomainName { get; set; }
        public string PublicDomainName { get; set; }
        public string RankedTeamDomainName { get; set; }
        public string TeamBuilderDomainName { get; set; }
    }

    public class ChatLcuSocialConfig
    {
        public bool AggressiveScanning { get; set; }
        public bool ForceChatFilter { get; set; }
        public long QueueJobGraceSeconds { get; set; }
        public bool SilenceChatWhileInGame { get; set; }
    }
}
