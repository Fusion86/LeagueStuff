using Jinx.Core;
using Jinx.Core.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Jinx.CLI
{
    class MenuItem
    {
        public AbilityBase Ability;
        public ConsoleKey ToggleKey;

        public MenuItem(AbilityBase ability, ConsoleKey toggleKey, bool isEnabled)
        {
            Ability = ability;
            ToggleKey = toggleKey;
        }
    }

    class Program
    {
        static readonly List<MenuItem> menuItems = new List<MenuItem>();

        static void Main(string[] args)
        {
            // Register abilities
            menuItems.Add(new MenuItem(new AutoAccept(), ConsoleKey.A, false));

            MainMenu();
        }

        static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine($"Jinx v{Assembly.GetExecutingAssembly().GetName().Version} (Core v{Assembly.GetAssembly(typeof(AbilityBase)).GetName().Version})\n");

            foreach (MenuItem item in menuItems)
            {
                Console.Write(item.ToggleKey + " - " + item.Ability.Name);
                Console.WriteLine(item.Ability.IsEnabled ? " [ Enabled ]" : " [ Disabled ]");
            }

            Console.WriteLine();
            Console.Write("> ");
            ConsoleKey key = Console.ReadKey().Key;

            MenuItem selectedItem = menuItems.FirstOrDefault(x => x.ToggleKey == key);

            if (selectedItem != null)
            {
                // stuff
            }
            else if (key == ConsoleKey.Q) return;
        }
    }
}
