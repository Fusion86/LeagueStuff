using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Hextech.LeagueClient
{
    public class Utility
    {
        // Based on https://github.com/Pupix/lcu-connector/blob/master/lib/index.js

        /// <summary>
        /// Gets the password and port (for the LeagueClient API) from the LeagueClientUx process args
        /// </summary>
        public static PasswordPort GetPasswordPort()
        {
            PlatformID platform = Environment.OSVersion.Platform;

            Process cmd = new Process();
            string authTokenRegex = "--remoting-auth-token=([\\w\\d-]+)";
            string portRegex = "--app-port=([\\d]+)";

            string authToken = null;
            int port = 0;

            if (platform == PlatformID.Win32NT)
            {
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.Arguments = "/C WMIC PROCESS WHERE name='LeagueClientUx.exe' GET commandline";
            }
            else if (platform == PlatformID.Unix)
            {
                cmd.StartInfo.FileName = "/bin/bash";
                cmd.StartInfo.Arguments = "-c \"ps x -o args | grep 'LeagueClientUx'\"";
            }
            else
            {
                throw new PlatformNotSupportedException();
            }

            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;

            cmd.Start();
            cmd.WaitForExit();

            string result = cmd.StandardOutput.ReadToEnd();

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

        /// <summary>
        /// Gets the LeagueClient install directory from the LeagueClientUx process args.
        /// This is also the directory that contains the 'lockfile' whenever the client is running
        ///
        /// Ex: /Applications/League of Legends.app/Contents/LoL/
        /// Ex: (windows example here)
        /// </summary>
        public static string GetLeagueClientInstallDirectory()
        {
            PlatformID platform = Environment.OSVersion.Platform;

            Process cmd = new Process();
            string installPathRegex = null;

            if (platform == PlatformID.Win32NT)
            {
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.Arguments = "/C WMIC PROCESS WHERE name='LeagueClientUx.exe' GET commandline";
                installPathRegex = "\"--install-directory=(.*?)\"";
            }
            else if (platform == PlatformID.Unix)
            {
                cmd.StartInfo.FileName = "/bin/bash";
                cmd.StartInfo.Arguments = "-c \"ps x -o args | grep 'LeagueClientUx'\"";
                installPathRegex = "--install-directory=(.*?)( --|\n|$)";
            }
            else
            {
                throw new PlatformNotSupportedException();
            }

            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;

            cmd.Start();
            cmd.WaitForExit();

            string result = cmd.StandardOutput.ReadToEnd();

            GroupCollection gc = Regex.Match(result, installPathRegex).Groups;

            if (gc.Count > 1) return gc[1].Value;
            else return null;
        }
    }
}
