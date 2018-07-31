using System.Collections.Generic;

namespace Hextech.LeagueClient.Models.ChampSelect
{
    public class TeamBoost
    {
        public List<long> AvailableSkins { get; set; }
        public long IpReward { get; set; }
        public long IpRewardForPurchaser { get; set; }
        public long Price { get; set; }
        public string SkinUnlockMode { get; set; }
        public long SummonerId { get; set; }
        public bool Unlocked { get; set; }
    }

}
