namespace Hextech.LeagueClient.Models.Inventory
{
    public class InventoryItem
    {
        public string InventoryType { get; set; }
        public long ItemId { get; set; }
        public ItemOwnershipType OwnershipType { get; set; }
        public string PurchaseDate { get; set; } // Undocumented
        public string Uuid { get; set; } // Undocumented
    }

    public enum ItemOwnershipType
    {
        OWNED,
        RENTED,
        F2P
    }
}
