using System.Diagnostics;

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

            };

            OnDisable += (sender, e) =>
            {

            };
        }
    }
}
