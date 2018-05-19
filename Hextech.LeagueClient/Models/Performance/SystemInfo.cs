namespace Hextech.LeagueClient.Models.Performance
{
    public class SystemInfo
    {
        public string CpuName { get; set; }
        public long CpuProcessorSpeed { get; set; }
        public long CoreCount { get; set; }
        public string GpuDriver { get; set; }
        public long GpuMemory { get; set; }
        public string GpuName { get; set; }
        public string OsVersion { get; set; }
        public long PhysicalMemory { get; set; }
    }
}
