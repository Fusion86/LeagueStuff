using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Jinx.Core.Abilities
{
    public abstract class AbilityBase
    {
        public abstract string Name { get; }
        public abstract string Description { get; }
        public abstract AbilityCategory Category { get; }

        public bool IsEnabled { get; private set; }

        protected EventHandler OnEnable;
        protected EventHandler OnDisable;

        protected AbilityBase()
        {
            OnEnable += (sender, e) =>
            {
                IsEnabled = true;
                Debug.WriteLine("Enabled " + Name);
            };

            OnDisable += (sender, e) =>
            {
                IsEnabled = false;
                Debug.WriteLine("Disabled " + Name);
            };
        }
    }
}
