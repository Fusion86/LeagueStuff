﻿using Hextech.LeagueClient;
using Hextech.LeagueClient.Models.System;
using Jinx.Core;
using Jinx.Core.Abilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Jinx.CLI
{
    class Program
    {
        static readonly Dictionary<ConsoleKey, MenuItem> menuItems = new Dictionary<ConsoleKey, MenuItem>();

        static readonly LeagueClientApi lc = new LeagueClientApi();

        static readonly string aboutString = $"Jinx v{Assembly.GetExecutingAssembly().GetName().Version} (Core v{Assembly.GetAssembly(typeof(AbilityBase)).GetName().Version})";
        static string leagueVersionString;

        static async Task Main(string[] args)
        {
            // Register abilities
            menuItems.Add(ConsoleKey.A, new MenuItem(new AutoAcceptAbility()));

            // Register action items
            menuItems.Add(ConsoleKey.B, new MenuItem("Print BuildInfo", async () =>
            {
                var info = await lc.System.GetBuildInfo();
                Console.WriteLine(JsonConvert.SerializeObject(info, Formatting.Indented));
            }));

            Console.WriteLine(aboutString + '\n');

            Console.WriteLine("Trying to connect to the LeagueClient...");
            bool success = await lc.Initialize();

            if (success)
            {
                Console.WriteLine("Connected to the LeagueClient");
                Console.WriteLine("Requestiong LeagueClient version...");
                BuildInfo info = await lc.System.GetBuildInfo();
                leagueVersionString = "LeagueClient version is " + info.Version;

                Console.WriteLine(leagueVersionString);
                Console.WriteLine();

                await MainMenuLoop();
            }
            else
            {
                Console.WriteLine("Couldn't connect to the LeagueClient");
                Console.WriteLine("Exiting...");
            }
        }

        static async Task MainMenuLoop()
        {
            bool first = true;
            var actionItems = menuItems.Where(x => x.Value.IsAbility == false);
            var abilityItems = menuItems.Where(x => x.Value.IsAbility == true);

            while (true)
            {
                if (first) first = false;
                else
                {
                    Console.Clear();

                    Console.WriteLine(aboutString + '\n');
                    Console.WriteLine(leagueVersionString + '\n');
                }

                foreach (var item in actionItems)
                {
                    Console.WriteLine(item.Key + " - " + item.Value.Name);
                }

                if (actionItems.Count() > 0) Console.WriteLine();

                foreach (var item in abilityItems)
                {
                    Console.Write(item.Key + " - " + item.Value.Name);

                    ConsoleColor oldColor = Console.ForegroundColor;
                    Console.ForegroundColor = item.Value.Ability.IsEnabled ? ConsoleColor.Green : ConsoleColor.Yellow;
                    Console.WriteLine(item.Value.Ability.IsEnabled ? " [ Enabled ]" : " [ Disabled ]");
                    Console.ForegroundColor = oldColor;
                }

                if (abilityItems.Count() > 0) Console.WriteLine();

                Console.Write("> ");

                ConsoleKey key = Console.ReadKey().Key;

                MenuItem selectedItem = null;
                menuItems.TryGetValue(key, out selectedItem);

                if (selectedItem != null)
                {
                    if (selectedItem.IsAbility)
                    {
                        if (selectedItem.Ability.IsEnabled) selectedItem.Ability.Disable();
                        else selectedItem.Ability.Enable();
                    }
                    else
                    {
                        Console.Clear();
                        await selectedItem.Run();
                        Console.WriteLine("\nPress enter to go back to the main menu...");
                        Console.ReadLine();
                    }
                }
                else if (key == ConsoleKey.Q) return;
            }
        }
    }
}