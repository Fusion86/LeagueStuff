namespace Hextech.LeagueClient.Models.RiotClient
{
    public class BasicSystemInfo
    {
        public BasicOperatingSystem OperatingSystem { get; set; }
        public long PhysicalMemory { get; set; }
        public long PhysicalProcessorCores { get; set; }
        public long ProcessorSpeed { get; set; }
    }

    public class BasicOperatingSystem
    {
        public string Edition { get; set; }
        public string Platform { get; set; }
        public string VersionMajor { get; set; }
        public string VersionMinor { get; set; }
    }
}
