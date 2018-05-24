using Newtonsoft.Json;

namespace Hextech.LeagueClient.Models.Performance
{
    // There is no official model for this object
    public class MemoryStatus
    {
        public int CaclulatedLargestFree { get; set; }
        public int CaclulatedTotalCommit { get; set; }
        public long CaclulatedTotalFree { get; set; }
        public int CaclulatedTotalReserved { get; set; }
        public decimal CpuAvgPeriod { get; set; }
        public decimal CpuAvgSample { get; set; }
        public decimal CpuAvgSystemTotal { get; set; }
        public decimal CpuAvgTotal { get; set; }
        public int PageFaultCount { get; set; }
        public int PagefileUsage { get; set; }
        public int PeakPagefileUsage { get; set; }
        public int PeakWorkingSetSize { get; set; }
        public int QuotaNonPagedPoolUsage { get; set; }
        public int QuotaPagedPoolUsage { get; set; }
        public int QuotaPeakNonPagedPoolUsage { get; set; }
        public int QuotaPeakPagedPoolUsage { get; set; }
        public int VirtualMemoryUsedAfterStaticInit { get; set; }
        public int WorkingSetSize { get; set; }
    }
}
