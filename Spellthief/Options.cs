using CommandLine;

namespace Spellthief
{
    class Options
    {
        [Option('i', "in", Required = true, HelpText = "Directory containing the files dumped by LuxInternal")]
        public string InDirectory { get; set; }

        [Option('o', "out", Required = true, HelpText = "Directory where the renamed files will be placed")]
        public string OutDirectory { get; set; }

        [Option("deletesource", Default = false, HelpText = "Delete source file when successfully processed")]
        public bool DeleteSource { get; set; }

        [Option('f', "found", Default = false, HelpText = "Print all found files")]
        public bool PrintFound { get; set; }

        [Option('u', "undetected", Default = false, HelpText = "Print all undetected files")]
        public bool PrintUndetected { get; set; }
    }
}
