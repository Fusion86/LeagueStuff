using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Jinx.Core.Abilities
{
    public class AutoAcceptAbility : AbilityBase
    {
        public override string Name => "Auto-Accept";
        public override string Description => "";
        public override AbilityCategory Category => AbilityCategory.Matchmaking;

        public AutoAcceptAbility()
        {
            OnEnable += (sender, e) =>
            {
                Debug.WriteLine("Conneeeeeeeect!");
            };

            OnDisable += (sender, e) =>
            {
                Debug.WriteLine("Disconneeeect!");
            };
        }
    }
}
