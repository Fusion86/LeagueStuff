using InjectionLibrary;
using JLibrary.PortableExecutable;
using System;
using System.Diagnostics;
using System.IO;

namespace KatarinaInjector
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                PrintHelp();
                return;
            }

            string file = args[1];
            if (!File.Exists(file))
            {
                Console.WriteLine($"File {file} doesn't exist!");
                return;
            }

            Process p = GetProcess(args[0]);

            if (p != null)
            {
                InjectionMethod injector = InjectionMethod.Create(InjectionMethodType.Standard);
                IntPtr hModule = IntPtr.Zero;

                using (var img = new PortableExecutable(file))
                    hModule = injector.Inject(img, p.Id);

                if (hModule != IntPtr.Zero)
                {
                    Console.WriteLine($"Injeted {file} into {p.ProcessName}");
                }
                else
                {
                    if (injector.GetLastError() != null)
                        Console.WriteLine(injector.GetLastError().Message);
                }
            }
        }

        private static void PrintHelp()
        {
            Console.WriteLine("Usage: KatarinaInjector.exe [process] [dll]");
            Console.WriteLine("Process: e.g. LeagueClient, LeagueClientUx");
            Console.WriteLine("Dll: e.g. Katarina.dll");
        }

        private static Process GetProcess(string name)
        {
            Process[] p = Process.GetProcessesByName(name);

            if (p.Length == 0)
            {
                Console.WriteLine($"{name} process not found!");
                return null;
            }
            else
            {
                Console.WriteLine($"Found {name} with pid {p[0].Id}");
                return p[0];
            }
        }
    }
}
