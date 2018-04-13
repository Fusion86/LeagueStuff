using Newtonsoft.Json;
using System.Collections.Generic;

namespace Hextech.LeagueClient.Models.GameData
{
    public class Champion : ILeagueClientModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("alias")]
        public string Alias { get; set; }

        [JsonProperty("squarePortraitPath")]
        public string SquarePortraitPath { get; set; }

        [JsonProperty("roles")]
        public List<Role> Roles { get; set; }

        public override string ToString() => Name;
    }

    public enum Role { Assassin, Fighter, Mage, Marksman, Support, Tank };
}
