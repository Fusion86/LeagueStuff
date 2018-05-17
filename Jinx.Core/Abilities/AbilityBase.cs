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

        public EventHandler OnEnable;
        public EventHandler OnDisable;

        public void Enable()
        {
            if (IsEnabled)
            {
                Debug.WriteLine(Name + " is already enabled!");
                return;
            }

            Debug.WriteLine("Enabling " + Name);
            IsEnabled = true;

            if (OnEnable != null) OnEnable(this, EventArgs.Empty);
        }

        public void Disable()
        {
            if (!IsEnabled)
            {
                Debug.WriteLine(Name + " is already disabled!");
                return;
            }

            Debug.WriteLine("Disabling " + Name);
            IsEnabled = false;
            if (OnDisable != null) OnDisable(this, EventArgs.Empty);
        }
    }
}
