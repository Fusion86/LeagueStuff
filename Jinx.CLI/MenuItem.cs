using Jinx.Core.Abilities;
using System;
using System.Threading.Tasks;

namespace Jinx.CLI
{
    class MenuItem
    {
        public string Name;
        public bool IsAbility => Ability != null;

        public AbilityBase Ability { get; private set; }
        public Func<Task> Run { get; private set; }

        public MenuItem(AbilityBase ability)
        {
            Name = ability.Name;
            Ability = ability;
        }

        public MenuItem(string name, Func<Task> run)
        {
            Name = name;
            Run = run;
        }
    }
}
