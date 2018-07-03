using System;
using System.Collections.Generic;

namespace Hextech.LeagueClient.Models.ItemSets
{
    // LolItemSetsItemSets, added -Collection to avoid collision with member 'ItemSets'
    public class ItemSetsCollection : JsonSerializable
    {
        public long AccountId { get; set; }
        public List<ItemSet> ItemSets { get; set; }
        public long Timestamp { get; set; }

        public ItemSetsCollection()
        {
            ItemSets = new List<ItemSet>();
        }
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

        public ItemSet()
        {
            AssociatedChampions = new List<int>();
            AssociatedMaps = new List<int>();
            Blocks = new List<Block>();
            Map = "any";
            Mode = "any";
            PreferredItemSlots = new List<PreferredItemSlotEntry>();
            StartedFrom = "blank";
            Type = "custom";
            Uid = Guid.NewGuid().ToString(); // I don't know how to get a legitimate Uid so the best we can do is generate a legit-looking one
        }
    }

    public class Block : JsonSerializable
    {
        public string HideIfSummonerSpell { get; set; }
        public List<Item> Items { get; set; }
        public string ShowIfSummonerSpell { get; set; }
        public string Type { get; set; }

        public Block()
        {
            Items = new List<Item>();
        }
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
