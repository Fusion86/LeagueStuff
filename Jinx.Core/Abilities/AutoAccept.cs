using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Jinx.Core.Abilities
{
    public class AutoAccept : AbilityBase
    {
        public override string Name => "Auto-Accept";
        public override string Description => "";
        public override AbilityCategory Category => AbilityCategory.Matchmaking;

        public AutoAccept()
        {
            OnEnable += (sender, e) =>
            {
                Debug.WriteLine("Yes,  really.");
            };
        }
    }
}
