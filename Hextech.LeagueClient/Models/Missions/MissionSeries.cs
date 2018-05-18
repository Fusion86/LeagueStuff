using Hextech.LeagueClient.JsonConverters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Hextech.LeagueClient.Models.Missions
{
    public class MissionSeries
    {
        public string Description { get; set; }
        public string DisplayType { get; set; }
        public string EligibilityType { get; set; }
        public string Id { get; set; }
        public string InternalName { get; set; }
        public MissionSeriesMedia Media { get; set; }
        public string OptInButtonText { get; set; }
        public string OptOutButtonText { get; set; }
        public string ParentName { get; set; }
        public string Status { get; set; }
        public List<string> Tags { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public bool Viewed { get; set; }
        public List<Alert> Warnings { get; set; }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime LastUpdatedTimestamp { get; set; }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime CreatedDate { get; set; }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime StartDate { get; set; }

        [JsonConverter(typeof(EpochConverter))]
        public DateTime EndDate { get; set; }
    }

    public class MissionSeriesMedia
    {
        public string AccentColor { get; set; }
        public string BackgroundImageLargeUrl { get; set; }
        public string BackgroundImageSmallUrl { get; set; }
        public string BackgroundUrl { get; set; }
    }
}
