namespace Hextech.LeagueClient.Models.Missions
{
    // No idea what this is tbh
    public class MissionMetadata
    {
        public MissionTutorial Tutorial { get; set; }
    }

    public class MissionTutorial
    {
        // public DisplayRewards DisplayRewards { get; set; }
        public string QueueId { get; set; }
        public long StepNumber { get; set; }
        public string UseQuickSearchMatchmaking { get; set; }
    }
}
