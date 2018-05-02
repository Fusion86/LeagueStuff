using System;
using System.Diagnostics;
using System.IO;
using System.Management;
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

        // Taken from https://github.com/Fumi24/RunesReformed/blob/master/RunesReformed1.1/Form1.cs#L210
        private PasswordPort GetPasswordPort()
        {
            Process[] procs = Process.GetProcessesByName("LeagueClientUx");

            if (procs.Length == 0) return null;

            foreach (var getid in procs)
            {
                using (ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT CommandLine FROM Win32_Process WHERE ProcessId = " + getid.Id))
                {
                    foreach (ManagementObject mo in mos.Get())
                    {
                        if (mo["CommandLine"] != null)
                        {
                            string data = (mo["CommandLine"].ToString());
                            string[] CommandlineArray = data.Split('"');
                            PasswordPort pp = new PasswordPort();

                            foreach (var attributes in CommandlineArray)
                            {
                                if (attributes.Contains("token") || attributes.Contains("remoting-auth-token"))
                                {
                                    string[] token = attributes.Split('=');
                                    pp.Password = token[1];
                                }
                                if (attributes.Contains("port") || attributes.Contains("app-port"))
                                {
                                    string[] port = attributes.Split('=');
                                    int.TryParse(port[1], out pp.Port);
                                }
                            }

                            return pp;
                        }
                    }
                }
            }

            return null;
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            PasswordPort pp = GetPasswordPort();

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
