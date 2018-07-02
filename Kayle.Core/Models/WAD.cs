// Based on https://github.com/LoL-Fantome/Fantome.Libraries.League/blob/619a02f2e447fa566627d4d2c23ac4a71d186096/Fantome.League/IO/WAD/WADFile.cs

using Kayle.Core.Logging;
using System;
using System.IO;
using System.Linq;

namespace Kayle.Core.Models
{
    public class WAD
    {
        private static readonly ILog Logger = LogProvider.For<WAD>();

        public static byte[] Magic = { 0x52, 0x57 }; // RW
        public ushort Major { get; private set; }
        public ushort Minor { get; private set; }

        public ushort ECDSALength { get; private set; }
        public byte[] ECDSA { get; private set; }
        public ulong DataChecksum { get; private set; } // xxHash64

        public UInt32 FileCount { get; private set; }

        public WAD(string path)
        {
            Logger.Info("Loading: " + path);

            using (FileStream fs = new FileStream(path, FileMode.Open))
            using (BinaryReader br = new BinaryReader(fs))
            {
                byte[] magic = br.ReadBytes(2);
                if (magic.SequenceEqual(magic) == false)
                {
                    throw new Exception("Magic doesn't match. Not a WAD file!");
                }

                Major = br.ReadByte();
                Minor = br.ReadByte();

                Logger.Info($"Version {Major}.{Minor}");

                if (Major > 3)
                {
                    throw new Exception("Unsupported version!");
                }

                switch (Major)
                {
                    case 2:
                        ECDSALength = br.ReadByte();
                        ECDSA = br.ReadBytes(ECDSALength);
                        fs.Position += 83 - ECDSALength;
                        DataChecksum = br.ReadUInt64();
                        break;
                    case 3:
                        ECDSALength = 256;
                        ECDSA = br.ReadBytes(ECDSALength);
                        DataChecksum = br.ReadUInt64();
                        break;
                }

                Logger.Info("ECDSALength = " + ECDSALength);
                Logger.Info($"DataChecksum = {DataChecksum:X8}");

                if (Major == 1 || Major == 2)
                {
                    // What's this?
                    ushort tocStartOffset = br.ReadUInt16();
                    ushort tocFileEntrySize = br.ReadUInt16();
                }

                FileCount = br.ReadUInt32();
                Logger.Info("FileCount = " + FileCount);
                for (int i = 0; i < FileCount; i++)
                {
                    // this._entries.Add(new WADEntry(this, br, this._major));
                }
            }
        }
    }
}
