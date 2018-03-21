using CommandLine;

namespace Xayah
{
    class Options
    {
        [Option('p', "password", Required = true)]
        public string Password { get; set; }

        [Option("port", Required = true)]
        public int Port { get; set; }

        [Option('o', "out", Required = true, HelpText = "Directory where the files will be placed")]
        public string OutDirectory { get; set; }
    }
}
