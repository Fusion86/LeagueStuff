using System.Collections.Generic;

namespace Hextech.LeagueClient.Models.GameData
{
    public class Champion
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public string SquarePortraitPath { get; set; }

        public List<Role> Roles { get; set; }
    }

    public enum Role { Assassin, Fighter, Mage, Marksman, Support, Tank };
}
