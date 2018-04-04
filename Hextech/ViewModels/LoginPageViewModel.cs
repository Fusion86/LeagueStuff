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

        private string m_quietPath;
        private string m_authPath;

       public LoginPageViewModel()
        {
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appPath = Path.Combine(appdata, "Katarina");
            appPath = Path.Combine(appPath, "KatarinaMini");

            m_quietPath = Path.Combine(appPath, "quiet");
            m_authPath = Path.Combine(appPath, "auth");

            Directory.CreateDirectory(appPath); // Create dirs if they don't exist
        }

        ~LoginPageViewModel()
        {
            // Make sure to clean after us
            try
            {
                if (File.Exists(m_quietPath))
                    File.Delete(m_quietPath);
            } catch (Exception) { }
        }

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

            using (File.Create(m_quietPath)) { } // Enable KatarinaInjector quiet modus

            Process p = new Process();
            p.StartInfo.FileName = injector;
            p.StartInfo.Arguments = "LeagueClientUx " + dll;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.WaitForExit();

            string res = p.StandardOutput.ReadToEnd();

            if (res.Contains("process not found"))
            {
                Status = "Please launch the League of Legends client.";
                return null;
            }

            Status = "Please click on something in the League of Legends client.";

            while (!File.Exists(m_authPath))
                await Task.Delay(100); // Possible deadlock

            string[] parts = File.ReadAllText(m_authPath).Split(new[] { ',' });

            PasswordPort pp = new PasswordPort();
            pp.Password = parts[0];
            pp.Port = int.Parse(parts[1]);

            try
            {
                File.Delete(m_authPath);
                File.Delete(m_authPath);
            }
            catch (Exception) { }

            Status = "Done!";

            return pp;
        }
    }
}
