using Newtonsoft.Json;

namespace Hextech.LeagueClient.Models
{
    public class BuildInfo
    {
        [JsonProperty("branch")]
        public string Branch { get; set; }

        [JsonProperty("branchFull")]
        public string BranchFull { get; set; }

        [JsonProperty("codeBuildId")]
        public long CodeBuildId { get; set; }

        [JsonProperty("contentBuildId")]
        public long ContentBuildId { get; set; }

        [JsonProperty("gameBranch")]
        public string GameBranch { get; set; }

        [JsonProperty("gameBranchFull")]
        public string GameBranchFull { get; set; }

        [JsonProperty("gameDataBuildId")]
        public long GameDataBuildId { get; set; }

        [JsonProperty("patchline")]
        public string Patchline { get; set; }

        [JsonProperty("patchlineVisibleName")]
        public string PatchlineVisibleName { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
