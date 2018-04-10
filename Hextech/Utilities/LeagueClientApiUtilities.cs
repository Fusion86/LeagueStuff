using Hextech.Models;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Hextech.Utilities
{
    public static class LeagueClientApiUtilities
    {
        public static async Task<LeagueClientPassport> GetPassport(IProgress<string> progress)
        {
            progress.Report("Launching...");

            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appPath = Path.Combine(appdata, "Katarina");
            appPath = Path.Combine(appPath, "KatarinaMini");

            string quietPath = Path.Combine(appPath, "quiet");
            string authPath = Path.Combine(appPath, "auth");

            Directory.CreateDirectory(appPath); // Create dirs if they don't exist

            const string injector = "KatarinaInjector.exe";
            const string dll = "KatarinaMini.dll";
            bool isMissingFiles = false;

            foreach (string file in new[] { injector, dll })
            {
                if (!File.Exists(file))
                {
                    isMissingFiles = true;
                    progress.Report($"Missing required file '{file}'");
                }
            }

            if (isMissingFiles)
            {
                progress.Report("Missing files!");
                return null;
            }

            using (File.Create(quietPath)) { } // Enable KatarinaInjector quiet modus
            File.Delete(authPath); // Make sure that we get new auth info

            Process p = new Process();
            p.StartInfo.FileName = injector;
            p.StartInfo.Arguments = "LeagueClientUx " + dll;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.WaitForExit();

            string res = p.StandardOutput.ReadToEnd();

            LeagueClientPassport pp = new LeagueClientPassport();

            if (res.Contains("process not found"))
            {
                progress.Report("Please launch the League of Legends client.");
            }
            else
            {
                progress.Report("Please click on something in the League of Legends client.");

                while (!File.Exists(authPath))
                    await Task.Delay(100); // Possible deadlock. When the user exits the program while we are blocking here then we don't cleanup our quiet lockfile, see comment below

                string[] parts = File.ReadAllText(authPath).Split(new[] { ',' });

                pp.Password = parts[0];
                pp.Port = int.Parse(parts[1]);

                progress.Report("Done!");
            }

            // FIXME: If the program is terminated before we reach this point then we DON'T cleanup the quiet lockfile (since the program exited)
            File.Delete(authPath);
            File.Delete(quietPath);

            return pp;
        }
    }
}
