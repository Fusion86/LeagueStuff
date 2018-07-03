using System.Collections.Generic;

namespace Hextech.LeagueClient.Models.ItemSets
{
    // LolItemSetsItemSets, added -Collection to avoid collision with member 'ItemSets'
    public class ItemSetsCollection : JsonSerializable
    {
        public long AccountId { get; set; }
        public List<ItemSet> ItemSets { get; set; }
        public long Timestamp { get; set; }
    }

    public class ItemSet : JsonSerializable
    {
        public List<int> AssociatedChampions { get; set; }
        public List<int> AssociatedMaps { get; set; }
        public List<Block> Blocks { get; set; }
        public string Map { get; set; }
        public string Mode { get; set; }
        public List<PreferredItemSlotEntry> PreferredItemSlots { get; set; } // Unused?
        public int Sortrank { get; set; }
        public string StartedFrom { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Uid { get; set; }
    }

    public class Block : JsonSerializable
    {
        public string HideIfSummonerSpell { get; set; }
        public List<Item> Items { get; set; }
        public string ShowIfSummonerSpell { get; set; }
        public string Type { get; set; }
    }

    public class Item : JsonSerializable
    {
        public int Count { get; set; }
        public int Id { get; set; }
    }

    // LolItemSetsPreferredItemSlot, added -Entry to avoid collision with member 'PreferredItemSlot'
    public class PreferredItemSlotEntry : JsonSerializable
    {
        public string Id { get; set; }
        public int PreferredItemSlot { get; set; }
    }
}
