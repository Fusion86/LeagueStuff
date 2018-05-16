using System;
using System.Collections.Generic;
using System.Text;

namespace Jinx.Core
{
    public class AbilityCategory
    {
        public static AbilityCategory Matchmaking = new AbilityCategory("Matchmaking");

        public string Name { get; }

        public AbilityCategory(string name)
        {
            Name = name;
        }
    }
}
