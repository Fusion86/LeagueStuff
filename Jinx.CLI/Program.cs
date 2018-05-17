using Hextech.LeagueClient;
using Jinx.Core;
using Jinx.Core.Abilities;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Jinx.CLI
{
    class Program
    {
        static readonly Dictionary<ConsoleKey, AbilityBase> menuItems = new Dictionary<ConsoleKey, AbilityBase>();

        static readonly LeagueClientApi lc = new LeagueClientApi();

        static void Main(string[] args)
        {
            // Register abilities
            menuItems.Add(ConsoleKey.A, new AutoAcceptAbility());

            MainMenu();
        }

        static void MainMenu()
        {
        menu:

            Console.Clear();
            Console.WriteLine($"Jinx v{Assembly.GetExecutingAssembly().GetName().Version} (Core v{Assembly.GetAssembly(typeof(AbilityBase)).GetName().Version})\n");

            Console.WriteLine();
            Console.Write("C - Connect to the LeagueClient");
            Console.WriteLine(lc.IsConnected ? " [ Connected ]" : " [ Not Connected ]");
            Console.WriteLine();

            foreach (var item in menuItems)
            {
                Console.Write(item.Key + " - " + item.Value.Name);
                Console.WriteLine(item.Value.IsEnabled ? " [ Enabled ]" : " [ Disabled ]");
            }

            Console.WriteLine();
            Console.Write("> ");

            ConsoleKey key = Console.ReadKey().Key;

            AbilityBase selectedAbility = null;
            menuItems.TryGetValue(key, out selectedAbility);

            if (selectedAbility != null)
            {
                if (selectedAbility.IsEnabled) selectedAbility.Disable();
                else selectedAbility.Enable();
            }
            else if (key == ConsoleKey.C) lc.Initialize().Wait();
            else if (key == ConsoleKey.Q) return;

            goto menu;
        }
    }
}
