namespace Hextech.LeagueClient.Models.Missions
{
    public class MissionObjective
    {
        public string Description { get; set; }
        public MissionProgress Progress { get; set; }
        public int Sequence { get; set; }
        public string Type { get; set; }
    }

    public class MissionProgress
    {
        public int CurrentProgress { get; set; }
        public int LastViewedProgress { get; set; }
        public int TotalCount { get; set; }
    }
}
