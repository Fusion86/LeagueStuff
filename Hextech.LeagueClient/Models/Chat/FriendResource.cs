namespace Hextech.LeagueClient.Models.Chat
{
    public class FriendResource
    {
        public string Availability { get; set; }
        public long DisplayGroupId { get; set; }
        public long GroupId { get; set; }
        public long Icon { get; set; }
        public long Id { get; set; }
        public bool IsP2PConversationMuted { get; set; }
        public object LastSeenOnlineTimestamp { get; set; }
        public FriendResourceExtraData Lol { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public string StatusMessage { get; set; }
    }

    public class FriendResourceExtraData
    {
        public string ProfileIcon { get; set; }
        public string ChampionId { get; set; }
        public string ClubsData { get; set; }
        public string GameQueueType { get; set; }
        public string GameStatus { get; set; }
        public string Level { get; set; }
        public string MapId { get; set; }
        public string SkinVariant { get; set; }
        public string Skinname { get; set; }
    }
}
