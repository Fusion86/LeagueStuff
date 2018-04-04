using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace Hextech.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Status { get; set; } = "Launching...";

        public async Task<PasswordPort> GetPasswordPort()
        {
            const string injector = "KatarinaInjector.exe";
            const string dll = "KatarinaMini.dll";
            bool isMissingFiles = false;

            foreach (string file in new[] { injector, dll })
            {
                if (!File.Exists(file))
                {
                    isMissingFiles = true;
                    MessageBox.Show($"Missing required file '{file}'");
                }
            }

            if (isMissingFiles)
            {
                Status = "Missing files!";
                return null;
            }

            // Enable KatarinaInjector quite modus
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appPath = Path.Combine(appdata, "Katarina");
            appPath = Path.Combine(appPath, "KatarinaMini");

            string quietPath = Path.Combine(appPath, "quiet");
            string authPath = Path.Combine(appPath, "auth");

            Directory.CreateDirectory(appPath); // Create dirs if they don't exist
            using (File.Create(quietPath)) { } // Create empty file

            Process p = new Process();
            p.StartInfo.FileName = injector;
            p.StartInfo.Arguments = "LeagueClientUx " + dll;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.Start();

            string res = p.StandardOutput.ReadToEnd();

            if (res.Contains("process not found"))
            {
                Status = "Please launch the League of Legends client and click start.";
                return null;
            }

            Status = "Please click on something in the League of Legends client.";

            while (true)
            {
                if (File.Exists(authPath))
                {
                    string[] parts = File.ReadAllText(authPath).Split(new[] { ',' });

                    PasswordPort pp = new PasswordPort();
                    pp.Password = parts[0];
                    pp.Port = int.Parse(parts[1]);

                    try
                    {
                        File.Delete(quietPath);
                        File.Delete(authPath);
                    }
                    catch (Exception ex) { }

                    Status = "Done!";

                    return pp;
                }

                await Task.Delay(100);
            }
        }
    }
}
