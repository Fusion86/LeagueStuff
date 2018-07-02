using Kayle.Core.Models;
using System;
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
        }
    }
}
