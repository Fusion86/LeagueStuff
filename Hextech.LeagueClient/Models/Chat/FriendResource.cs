using Newtonsoft.Json;

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
        [JsonProperty("profileIcon", NullValueHandling = NullValueHandling.Ignore)]
        public string ProfileIcon { get; set; }

        [JsonProperty("championId", NullValueHandling = NullValueHandling.Ignore)]
        public string ChampionId { get; set; }

        [JsonProperty("clubsData", NullValueHandling = NullValueHandling.Ignore)]
        public string ClubsData { get; set; }

        [JsonProperty("gameQueueType", NullValueHandling = NullValueHandling.Ignore)]
        public string GameQueueType { get; set; }

        [JsonProperty("gameStatus", NullValueHandling = NullValueHandling.Ignore)]
        public string GameStatus { get; set; }

        [JsonProperty("level", NullValueHandling = NullValueHandling.Ignore)]
        public string Level { get; set; }

        [JsonProperty("mapId", NullValueHandling = NullValueHandling.Ignore)]
        public string MapId { get; set; }

        [JsonProperty("skinVariant", NullValueHandling = NullValueHandling.Ignore)]
        public string SkinVariant { get; set; }

        [JsonProperty("skinname", NullValueHandling = NullValueHandling.Ignore)]
        public string Skinname { get; set; }
    }
}
