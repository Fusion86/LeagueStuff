using System.Collections.Generic;

namespace Hextech.LeagueClient.Models.Perks
{
    public class Style
    {
        public List<long> AllowedSubStyles { get; set; }
        public Dictionary<string, string> AssetMap { get; set; }
        public string DefaultPageName { get; set; }
        public List<long> DefaultPerks { get; set; }
        public long DefaultSubStyle { get; set; }
        public string IconPath { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public List<Slot> Slots { get; set; }
        public List<SubStyleBonus> SubStyleBonus { get; set; }
        public string Tooltip { get; set; }
    }

    public class Slot
    {
        public List<long> Perks { get; set; }
        public string SlotLabel { get; set; }
        public TypeEnum Type { get; set; }
    }

    public class SubStyleBonus
    {
        public long PerkId { get; set; }
        public long StyleId { get; set; }
    }

    public enum TypeEnum
    {
        KKeyStone,
        KMixedRegularSplashable
    };
}
