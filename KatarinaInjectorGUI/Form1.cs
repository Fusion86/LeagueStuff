using InjectionLibrary;
using JLibrary.PortableExecutable;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace KatarinaInjectorGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDlls();
        }

        private void LoadDlls()
        {
            DirectoryInfo dirInfo = new DirectoryInfo("Inject");

            if (!dirInfo.Exists)
            {
                Directory.CreateDirectory(dirInfo.Name);
                Log("Created directory " + dirInfo.Name);
            }

            cmbDlls.Invoke(new Action(() =>
            {
                cmbDlls.Items.Clear();

                foreach (FileInfo info in dirInfo.GetFiles())
                {
                    if (info.Extension == ".dll")
                    {
                        cmbDlls.Items.Add(info.Name);

                    }
                }
            }));
        }

        private void Log(string str)
        {
            txtLog.Invoke(new Action(() =>
            {
                txtLog.AppendText(str + Environment.NewLine);
            }));
        }

        private Process GetProcess(string name)
        {
            Process[] p = Process.GetProcessesByName(name);

            if (p.Length == 0)
            {
                Log($"{name} process not found!");
                return null;
            }
            else
            {
                Log($"Found {name} with pid {p[0].Id}");
                return p[0];
            }
        }

        private bool Inject(Process process, string path)
        {
            InjectionMethod injector = InjectionMethod.Create(InjectionMethodType.Standard);
            IntPtr hModule = IntPtr.Zero;

            using (var img = new PortableExecutable(path))
                hModule = injector.Inject(img, process.Id);

            if (hModule != IntPtr.Zero)
            {
                return true;
            }
            else
            {
                if (injector.GetLastError() != null)
                    MessageBox.Show(injector.GetLastError().Message);

                return false;
            }
        }

        private void btnLeagueClient_Click(object sender, EventArgs e)
        {
            Process p = GetProcess("LeagueClient");

            if (p != null)
            {
                string path = Path.Combine("Inject", cmbDlls.SelectedItem.ToString());
                if (File.Exists(path))
                {
                    Inject(p, path);
                }
                else
                {
                    Log("Couldn't find DLL " + path);
                }
            }
        }

        private void btnLeagueClientUx_Click(object sender, EventArgs e)
        {
            Process p = GetProcess("LeagueClientUx");

            if (p != null)
            {
                string path = Path.Combine("Inject", cmbDlls.SelectedItem.ToString());
                if (File.Exists(path))
                {
                    Inject(p, path);
                    Log($"Injected {path} into {p.ProcessName}");
                }
                else
                {
                    Log("Couldn't find DLL " + path);
                }
            }
        }

        private void btnReloadDlls_Click(object sender, EventArgs e)
        {
            LoadDlls();
        }
    }
}
