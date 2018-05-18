namespace Hextech.LeagueClient.Models.Missions
{
    public class MissionReward
    {
        public string Description { get; set; }
        public string IconUrl { get; set; }
        public string ItemId { get; set; }
        public MissionRewardMedia Media { get; set; }
        public bool RewardFulfilled { get; set; }
        public string RewardType { get; set; }
        public int Sequence { get; set; }
        public string UniqueName { get; set; }
    }

    public class MissionRewardMedia
    {
        public MissionRewardMediaItem Intro { get; set; }
        public MissionRewardMediaItem Loop { get; set; }
        public MissionRewardMediaItem Outro { get; set; }
    }

    public class MissionRewardMediaItem
    {
        public string Sound { get; set; }
        public string Video { get; set; }
    }
}
