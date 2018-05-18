using System.Collections.Generic;

namespace Hextech.LeagueClient.Models.Missions
{
    public class PlayerMission
    {
        public string BackgroundImageUrl { get; set; }
        public string CelebrationType { get; set; }
        public string ClientNotifyLevel { get; set; }
        public long CompletedDate { get; set; }
        public string CompletionExpression { get; set; }
        public long CooldownTimeMillis { get; set; }
        public string Description { get; set; }
        public string DisplayType { get; set; }
        public long EndTime { get; set; }
        public List<MissionAlert> ExpiringWarnings { get; set; }
        public string HelperText { get; set; }
        public string IconImageUrl { get; set; }
        public string Id { get; set; }
        public string InternalName { get; set; }
        public bool IsNew { get; set; }
        public long LastUpdatedTimestamp { get; set; }
        public string Locale { get; set; }
        public MissionMetadata Metadata { get; set; }
        public string MissionType { get; set; }
        public List<MissionObjective> Objectives { get; set; }
        public List<string> Requirements { get; set; }
        public List<MissionReward> Rewards { get; set; }
        public string SeriesName { get; set; }
        public long StartTime { get; set; }
        public string Status { get; set; }
        public string Title { get; set; }
        public bool Viewed { get; set; }
    }
}
