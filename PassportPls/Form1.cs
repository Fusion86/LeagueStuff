using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassportPls
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnStart.PerformClick();
        }

        private void SetStatus(string str)
        {
            lblStatus.Invoke(new Action(() =>
            {
                lblStatus.Text = str;
            }));
        }

        private async Task<PasswordPort> GetPasswordPort()
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
                return null;

            // Enable KatarinaInjector quite modus
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appPath = Path.Combine(appdata, "Katarina");
            appPath = Path.Combine(appPath, "KatarinaMini");

            string quietPath = Path.Combine(appPath, "quiet");
            string authPath = Path.Combine(appPath, "auth");

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
                SetStatus("Please launch the League of Legends client and try again.");
                return null;
            }

            SetStatus("Please click on something in the League of Legends client.");

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
                    } catch (Exception ex) { }

                    SetStatus("Done!");

                    return pp;
                }

                await Task.Delay(100);
            }
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            PasswordPort pp = await GetPasswordPort();

            if (pp != null)
            {
                txtPassword.Invoke(new Action(() =>
                {
                    txtPassword.Text = pp.Password;
                    txtPort.Text = pp.Port.ToString();
                }));
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Try to cleanup
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appPath = Path.Combine(appdata, "Katarina");
            appPath = Path.Combine(appPath, "KatarinaMini");

            string quietPath = Path.Combine(appPath, "quiet");
            string authPath = Path.Combine(appPath, "auth");

            try
            {
                File.Delete(quietPath);
                File.Delete(authPath);
            }
            catch (Exception ex) { }
        }
    }
}
