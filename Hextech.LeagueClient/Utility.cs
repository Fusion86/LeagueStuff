using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Hextech.LeagueClient
{
    public class Utility
    {
        // Based on https://github.com/Pupix/lcu-connector/blob/master/lib/index.js
        public static PasswordPort GetPasswordPort()
        {
            PlatformID platform = Environment.OSVersion.Platform;

            if (platform == PlatformID.Win32NT)
            {
                Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.StartInfo.Arguments = "/C WMIC PROCESS WHERE name='LeagueClientUx.exe' GET commandline";
                cmd.Start();
                cmd.WaitForExit();

                string result = cmd.StandardOutput.ReadToEnd();

                string authTokenRegex = "\"--remoting-auth-token=([\\w\\d]+)\"";
                string portRegex = "\"--app-port=([\\d]+)\"";

                string authToken = null;
                int port = 0;

                GroupCollection gc = Regex.Match(result, authTokenRegex).Groups;
                if (gc.Count > 1) authToken = gc[1].Value;

                gc = Regex.Match(result, portRegex).Groups;
                if (gc.Count > 1) int.TryParse(gc[1].Value, out port);

                if (authToken != null && port != 0)
                {
                    return new PasswordPort
                    {
                        Password = authToken,
                        Port = port
                    };
                }

                return null;
            }
            else if (platform == PlatformID.Unix)
            {
                throw new NotImplementedException();
            }
            else
            {
                throw new PlatformNotSupportedException();
            }
        }
    }
}
