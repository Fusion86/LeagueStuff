using Newtonsoft.Json;

namespace Hextech.LeagueClient.Models.GameData
{
    public partial class Champion
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("alias")]
        public string Alias { get; set; }

        [JsonProperty("squarePortraitPath")]
        public string SquarePortraitPath { get; set; }

        //[JsonProperty("roles")]
        //public List<Role> Roles { get; set; }
    }

    //public enum Role { Assassin, Fighter, Mage, Marksman, Support, Tank };
}
