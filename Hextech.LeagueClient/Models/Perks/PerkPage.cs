using Newtonsoft.Json;
using System.Collections.Generic;

namespace Hextech.LeagueClient.Models.Perks
{
    public class PerkPage
    {
        public List<int> AutoModifiedSelections { get; set; }
        public bool Current { get; set; }
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeletable { get; set; }
        public bool IsEditable { get; set; }
        public bool IsValid { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public int PrimaryStyleId { get; set; }
        public List<int> SelectedPerkIds { get; set; }
        public int SubStyleId { get; set; }
    }
}
