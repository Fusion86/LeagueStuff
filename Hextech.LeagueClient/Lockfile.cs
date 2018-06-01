using System;
using System.IO;

namespace Hextech.LeagueClient
{
    public class Lockfile
    {
        // Lockfile data
        public string Name { get; private set; }
        public int Pid { get; private set; } // Probably
        public int Port { get; private set; }
        public string AuthToken { get; private set; }
        public string Protocol { get; private set; }

        // Meta
        public event EventHandler Updated;
        public string Path => System.IO.Path.Combine(m_watcher.Path, m_watcher.Filter); // See ctor()
        public bool FileExists => File.Exists(Path);
        public bool EnableRaisingEvents
        {
            get => m_watcher.EnableRaisingEvents;
            set => m_watcher.EnableRaisingEvents = value;
        }

        private readonly FileSystemWatcher m_watcher = new FileSystemWatcher();

        public Lockfile(string path)
        {
            m_watcher.Path = System.IO.Path.GetDirectoryName(path);
            m_watcher.Filter = System.IO.Path.GetFileName(path);
            m_watcher.Created += OnCreated;

            Reload();
        }

        public void Reload()
        {
            if (FileExists)
            {
                string[] arr = File.ReadAllText(Path).Split(':');

                Name = arr[0];
                Pid = int.Parse(arr[1]);
                Port = int.Parse(arr[2]);
                AuthToken = arr[3];
                Protocol = arr[4];

                if (Updated != null)
                {
                    Updated(this, EventArgs.Empty);
                }
            }
        }

        private void OnCreated(object source, FileSystemEventArgs e)
        {
            Reload();
        }
    }
}
