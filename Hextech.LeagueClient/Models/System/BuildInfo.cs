namespace Hextech.LeagueClient.Models.System
{
    public class BuildInfo
    {
        public string Branch { get; set; }
        public string BranchFull { get; set; }
        public long CodeBuildId { get; set; }
        public long ContentBuildId { get; set; }
        public string GameBranch { get; set; }
        public string GameBranchFull { get; set; }
        public long GameDataBuildId { get; set; }
        public string Patchline { get; set; }
        public string PatchlineVisibleName { get; set; }
        public string Version { get; set; }
    }
}
