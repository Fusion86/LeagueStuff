using Kayle.Core.Models;
using System;
using System.IO;
using System.Reflection;

namespace Kayle.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Core.Logging.LogProvider.SetCurrentLogProvider(new ColoredConsoleLogProvider());

            Console.WriteLine($"Kayle.CLI v{Assembly.GetExecutingAssembly().GetName().Version}");
            Console.WriteLine($"Kayle.Core v{Assembly.GetAssembly(typeof(WAD)).GetName().Version}");

            if (args.Length == 0)
            {
                Console.WriteLine("Please specify the WAD file path.");
                return;
            }

            string wadfile = args[0];

            if (File.Exists(wadfile) == false)
            {
                Console.WriteLine($"The file '{wadfile}' doesn't exist!");
                return;
            }

            WAD wad = new WAD(wadfile);
        }
    }
}
