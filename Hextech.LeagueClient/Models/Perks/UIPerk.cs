using Newtonsoft.Json;

namespace Hextech.LeagueClient.Models.Perks
{
    public class UIPerk
    {
        public string IconPath { get; set; }
        public int Id { get; set; }
        public string LongDesc { get; set; }
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string Tooltip { get; set; }
    }
}
