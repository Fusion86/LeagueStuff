namespace Hextech.LeagueClient.Models.Summoner
{
    public class Summoner : JsonSerializable
    {
        public long AccountId { get; set; }
        public string DisplayName { get; set; }
        public string InternalName { get; set; }
        public string LastSeasonHighestRank { get; set; }
        public long PercentCompleteForNextLevel { get; set; }
        public long ProfileIconId { get; set; }
        public string Puuid { get; set; }
        public RerollPoints RerollPoints { get; set; }
        public long SummonerId { get; set; }
        public long SummonerLevel { get; set; }
        public long XpSinceLastLevel { get; set; }
        public long XpUntilNextLevel { get; set; }
    }

    public class RerollPoints : JsonSerializable
    {
        public long CurrentPoints { get; set; }
        public long MaxRolls { get; set; }
        public long NumberOfRolls { get; set; }
        public long PointsCostToRoll { get; set; }
        public long PointsToReroll { get; set; }
    }
}
