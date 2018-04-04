using Newtonsoft.Json;

namespace Hextech.LeagueClient.Models.Summoner
{
    public class Summoner
    {
        [JsonProperty("accountId", Required = Required.Always)]
        public long AccountId { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("internalName")]
        public string InternalName { get; set; }

        [JsonProperty("lastSeasonHighestRank")]
        public string LastSeasonHighestRank { get; set; }

        [JsonProperty("percentCompleteForNextLevel")]
        public long PercentCompleteForNextLevel { get; set; }

        [JsonProperty("profileIconId")]
        public long ProfileIconId { get; set; }

        [JsonProperty("puuid")]
        public string Puuid { get; set; }

        [JsonProperty("rerollPoints")]
        public RerollPoints RerollPoints { get; set; }

        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }

        [JsonProperty("summonerLevel")]
        public long SummonerLevel { get; set; }

        [JsonProperty("xpSinceLastLevel")]
        public long XpSinceLastLevel { get; set; }

        [JsonProperty("xpUntilNextLevel")]
        public long XpUntilNextLevel { get; set; }
    }

    public class RerollPoints
    {
        [JsonProperty("currentPoints", Required = Required.Always)]
        public long CurrentPoints { get; set; }

        [JsonProperty("maxRolls")]
        public long MaxRolls { get; set; }

        [JsonProperty("numberOfRolls")]
        public long NumberOfRolls { get; set; }

        [JsonProperty("pointsCostToRoll")]
        public long PointsCostToRoll { get; set; }

        [JsonProperty("pointsToReroll")]
        public long PointsToReroll { get; set; }
    }
}
