using Newtonsoft.Json;

namespace Hextech.LeagueClient.Models.Performance
{
    // There is no official model for this object
    public class MemoryStatus
    {
        [JsonProperty("CaclulatedLargestFree", NullValueHandling = NullValueHandling.Ignore)]
        public int CaclulatedLargestFree { get; set; }

        [JsonProperty("CaclulatedTotalCommit", NullValueHandling = NullValueHandling.Ignore)]
        public int CaclulatedTotalCommit { get; set; }

        [JsonProperty("CaclulatedTotalFree", NullValueHandling = NullValueHandling.Ignore)]
        public long CaclulatedTotalFree { get; set; }

        [JsonProperty("CaclulatedTotalReserved", NullValueHandling = NullValueHandling.Ignore)]
        public int CaclulatedTotalReserved { get; set; }

        [JsonProperty("CpuAvgPeriod", NullValueHandling = NullValueHandling.Ignore)]
        public decimal CpuAvgPeriod { get; set; }

        [JsonProperty("CpuAvgSample", NullValueHandling = NullValueHandling.Ignore)]
        public decimal CpuAvgSample { get; set; }

        [JsonProperty("CpuAvgSystemTotal", NullValueHandling = NullValueHandling.Ignore)]
        public decimal CpuAvgSystemTotal { get; set; }

        [JsonProperty("CpuAvgTotal", NullValueHandling = NullValueHandling.Ignore)]
        public decimal CpuAvgTotal { get; set; }

        [JsonProperty("PageFaultCount", NullValueHandling = NullValueHandling.Ignore)]
        public int PageFaultCount { get; set; }

        [JsonProperty("PagefileUsage", NullValueHandling = NullValueHandling.Ignore)]
        public int PagefileUsage { get; set; }

        [JsonProperty("PeakPagefileUsage", NullValueHandling = NullValueHandling.Ignore)]
        public int PeakPagefileUsage { get; set; }

        [JsonProperty("PeakWorkingSetSize", NullValueHandling = NullValueHandling.Ignore)]
        public int PeakWorkingSetSize { get; set; }

        [JsonProperty("QuotaNonPagedPoolUsage", NullValueHandling = NullValueHandling.Ignore)]
        public int QuotaNonPagedPoolUsage { get; set; }

        [JsonProperty("QuotaPagedPoolUsage", NullValueHandling = NullValueHandling.Ignore)]
        public int QuotaPagedPoolUsage { get; set; }

        [JsonProperty("QuotaPeakNonPagedPoolUsage", NullValueHandling = NullValueHandling.Ignore)]
        public int QuotaPeakNonPagedPoolUsage { get; set; }

        [JsonProperty("QuotaPeakPagedPoolUsage", NullValueHandling = NullValueHandling.Ignore)]
        public int QuotaPeakPagedPoolUsage { get; set; }

        [JsonProperty("VirtualMemoryUsedAfterStaticInit", NullValueHandling = NullValueHandling.Ignore)]
        public int VirtualMemoryUsedAfterStaticInit { get; set; }

        [JsonProperty("WorkingSetSize", NullValueHandling = NullValueHandling.Ignore)]
        public int WorkingSetSize { get; set; }
    }
}
