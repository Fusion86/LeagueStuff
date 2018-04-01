using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hextech.Managers
{
    public sealed class LeagueClientManager
    {
        private static readonly Lazy<LeagueClientManager> lazy = new Lazy<LeagueClientManager>(() => new LeagueClientManager());
        public static LeagueClientManager Instance => lazy.Value;

        public int Port { get; private set; }
        public string Password { get; private set; }

        private LeagueClientManager()
        {
            // Accept untrusted SSL certs
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
        }

        public bool Login(int port, string password)
        {
            return false;
        }
    }
}
