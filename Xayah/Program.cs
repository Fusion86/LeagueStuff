using CommandLine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Xayah
{
    class Program
    {
        static string username = "riot";
        static string password;
        static int port;

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
              .WithParsed(opts => RunOptionsAndReturnExitCode(opts))
              .WithNotParsed((errs) => HandleParseError(errs));
        }

        static int RunOptionsAndReturnExitCode(Options options)
        {
            if (!Directory.Exists(options.OutDirectory))
            {
                Console.WriteLine($"The output directory '{options.OutDirectory}' doesn't exist!");
                return 1;
            }

            password = options.Password;
            port = options.Port;

            // Ignore SSL errors (which do happen since we don't have the Riot cert installed, but that's fine as long as we just ignore those)
            ServicePointManager.ServerCertificateValidationCallback = (a, b, c, d) => true;

            string index;

            try
            {
                index = DownloadStringFromApiDocs();
            }
            catch (Exception ex)
            {
                // Probably wrong password or port
                Console.WriteLine(ex.Message);
                return 1;
            }

            JObject o = JObject.Parse(index);

            string outPathBase = Path.Combine(options.OutDirectory, o["info"]["description"].Value<string>());
            Directory.CreateDirectory(outPathBase); // Nothing happens if it already exists
            string indexPath = Path.Combine(outPathBase, "index.json");

            File.WriteAllTextAsync(indexPath, index);
            Console.WriteLine($"Downloaded index".PadRight(40) + $"'{indexPath}'");

            bool hasAlreadyExportedModels = false;

            Parallel.ForEach(o["apis"], (x) =>
            {
                string path = x["path"].Value<string>();
                string content = DownloadStringFromApiDocs(path);
                string fileName = path.Substring(1) + ".json"; // Cut off the starting '/'
                string outPath = Path.Combine(outPathBase, fileName);

                JObject sub = JObject.Parse(content);

                if (!hasAlreadyExportedModels)
                {
                    hasAlreadyExportedModels = true;

                    string modelsPath = Path.Combine(outPathBase, "models.json");

                    File.WriteAllText(modelsPath, sub["models"].ToString());
                    Console.WriteLine($"Downloaded models".PadRight(40) + $"'{outPath}'");
                }

                File.WriteAllText(outPath, sub["apis"].ToString());
                Console.WriteLine($"Downloaded {path}".PadRight(40) + $"'{outPath}'");
            });

            return 0;
        }

        static string DownloadStringFromApiDocs(string sub = null)
        {
            string url = $"https://127.0.0.1:{port}/v1/api-docs";
            if (sub != null) url += sub;

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            String encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
            req.Headers.Add("Authorization", "Basic " + encoded);

            HttpWebResponse res = (HttpWebResponse)req.GetResponse();

            using (StreamReader sr = new StreamReader(res.GetResponseStream()))
            {
                return sr.ReadToEnd();
            }
        }

        static void HandleParseError(IEnumerable<Error> errs)
        {

        }
    }
}
