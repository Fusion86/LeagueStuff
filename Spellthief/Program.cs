using CommandLine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Spellthief
{
    class Program
    {
        enum LeagueFileType
        {
            AutoSelectedKeystones,
            Champion,
            Champions,
            Config,
            DiscordStates,
            GameModes,
            Keystones,
            Maps,
            ProfileIconAssetMap,
            Runes,
            UniqueGameModes,
            Unknown,
            FeaturedGameModes,
        }

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
              .WithParsed(opts => RunOptionsAndReturnExitCode(opts))
              .WithNotParsed((errs) => HandleParseError(errs));
        }

        static int RunOptionsAndReturnExitCode(Options options)
        {
            // Verify input

            if (!Directory.Exists(options.InDirectory))
            {
                Console.Error.WriteLine($"The input directory '{options.InDirectory}' doesn't exist!");
                return 1;
            }

            string[] files = Directory.GetFiles(options.InDirectory);

            if (files.Length == 0)
            {
                Console.Error.WriteLine($"The input directory '{options.InDirectory}' is empty!");
                return 1;
            }

            if (!Directory.Exists(options.OutDirectory))
            {
                Console.Error.WriteLine($"The output directory '{options.OutDirectory}' doesn't exist!");
                return 1;
            }

            // Created needed output directories

            Directory.CreateDirectory(Path.Combine(options.OutDirectory, "Champions"));

            // Do work

            Parallel.ForEach(files, (file) =>
            {
                string text = File.ReadAllText(file);

                if (text[0] == '{' || text[0] == '[')
                {
                    JToken root = null;

                    try
                    {
                        root = JToken.Parse(text);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"File: '{file}'");
                        Console.WriteLine(ex.Message);
                    }

                    if (root is JObject)
                        ProcessJsonFile((JObject)root, file, options);
                    else if (root is JArray)
                        ProcessJsonFile((JArray)root, file, options);
                }
                else
                {
                    ProcessTextFile(text, file, options);
                }
            });

            return 0;
        }

        static void HandleParseError(IEnumerable<Error> errs)
        {

        }

        static LeagueFileType GetLeagueFileType(JToken root)
        {
            if (root.Type == JTokenType.Object)
            {
                if (root["shortBio"] != null) return LeagueFileType.Champion;
                if (root["files"] is JArray) return LeagueFileType.Config;
                if (root["Disc_Pres_Map_10"] != null) return LeagueFileType.DiscordStates;
                //if (root.First is JObject)
                //{
                //    if (root.First["detailedDescription"] != null) return LeagueFileType.UniqueGameModes;
                //}
                //if (root.First is JArray)
                //{
                //    if (root.First.First is JObject && root.First.First["isRGM"] != null) return LeagueFileType.FeaturedGameModes;
                //}
            }
            else if (root.Type == JTokenType.Array)
            {
                if (root[0]["mapStringId"] != null) return LeagueFileType.Maps;
                if (root[0]["squarePortraitPath"] != null) return LeagueFileType.Champions;
                //if (root[0] is JArray && root[0][0]["gameMode"] != null) return LeagueFileType.GameModes; // Doesn't work
                if (root[0]["endOfGameStatDescs"] != null) return LeagueFileType.Runes;
                if (root[0]["allowedSubStyles"] != null) return LeagueFileType.Keystones;
                if (root[0]["style"] != null) return LeagueFileType.AutoSelectedKeystones;
                if (root[0]["iconPath"] != null) return LeagueFileType.ProfileIconAssetMap;
            }

            return LeagueFileType.Unknown;
        }

        static void ProcessJsonFile(JToken root, string file, Options options)
        {
            LeagueFileType type = GetLeagueFileType(root);

            string outPath = options.OutDirectory;
            string name = Enum.GetName(typeof(LeagueFileType), type);
            string foundMessage = null;

            switch (type)
            {
                case LeagueFileType.Champion:
                    outPath = Path.Combine(outPath, "Champions");
                    name = root["name"].ToString();
                    foundMessage = $"Found champion {name}";
                    break;
            }

            if (type != LeagueFileType.Unknown)
            {
                string fileName = name;

                foreach (char c in Path.GetInvalidFileNameChars())
                    fileName = fileName.Replace(c, '_');

                fileName += ".json";
                outPath = Path.Combine(outPath, fileName);

                if (options.PrintFound)
                {
                    if (foundMessage == null)
                        foundMessage = $"Found {name}";
                    
                    Console.WriteLine(foundMessage.PadRight(24) + $"'{outPath}'");
                }

                try
                {
                    File.WriteAllText(outPath, JsonConvert.SerializeObject(root, Formatting.Indented));

                    if (options.DeleteSource)
                        File.Delete(file);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                if (options.PrintUndetected)
                    Console.WriteLine("Unknown JSON file!".PadRight(48) + $"'{file}'");
            }
        }

        static void ProcessTextFile(string text, string file, Options options)
        {

        }
    }
}
