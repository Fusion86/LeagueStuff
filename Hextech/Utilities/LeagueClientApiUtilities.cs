using Hextech.Models;
using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Threading.Tasks;

namespace Hextech.Utilities
{
    public static class LeagueClientApiUtilities
    {
        // Taken from https://github.com/Fumi24/RunesReformed/blob/master/RunesReformed1.1/Form1.cs#L210
        public static LeagueClientPassport GetPassport()
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
                            LeagueClientPassport pp = new LeagueClientPassport();

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
    }
}
