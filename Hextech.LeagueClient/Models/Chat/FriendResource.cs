using Newtonsoft.Json;

namespace Hextech.LeagueClient.Models.Chat
{
    public class FriendResource
    {
        [JsonProperty("availability", Required = Required.Always)]
        public string Availability { get; set; }

        [JsonProperty("displayGroupId")]
        public long DisplayGroupId { get; set; }

        [JsonProperty("groupId")]
        public long GroupId { get; set; }

        [JsonProperty("icon")]
        public long Icon { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("isP2PConversationMuted")]
        public bool IsP2PConversationMuted { get; set; }

        [JsonProperty("lastSeenOnlineTimestamp")]
        public object LastSeenOnlineTimestamp { get; set; }

        [JsonProperty("lol")]
        public LolChatFriendResourceExtraData Lol { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("statusMessage")]
        public string StatusMessage { get; set; }
    }
    
    public class LolChatFriendResourceExtraData
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
