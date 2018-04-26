using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MDLToMaterials
{
    internal class Program
    {
        private static void RecurseAddItems(string path, List<string> list)
        {
            foreach (var item in Directory.GetDirectories(path))
            {
                RecurseAddItems(Path.Combine(path, item), list);
            }

            list.AddRange(Directory.GetFiles(path).Where(item => Path.GetExtension(item) == ".mdl"));
        }

        private static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Drop the file/folder you want to extract info from on the exe!");
                Console.Read();
                return;
            }

            var paths = new List<string>();
            var singlefile = false;
            if (Directory.Exists(args[0]))
            {
                RecurseAddItems(args[0], paths);
            }
            else
            {
                if (Path.GetExtension(args[0]) != ".mdl")
                {
                    Console.WriteLine("File must be a .mdl!");
                    Console.Read();
                    return;
                }
                singlefile = true;
                paths.Add(args[0]);
            }

            var texoutput = new StringBuilder();
            var diroutput = new StringBuilder();
            foreach (var item in paths)
            {
                Console.Write("Outputting " + Path.GetFileName(item));

                try
                {
                    using (var reader = new BinaryReader(File.Open(item, FileMode.Open)))
                    {
                        Mdl.Read(reader, texoutput, diroutput);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Failed!\n{0}", e);
                }
            }

            var finalout = new StringBuilder();
            finalout.AppendLine("directories:\r\n");
            finalout.Append(diroutput);
            finalout.AppendLine();
            finalout.AppendLine("files:\r\n");
            finalout.Append(texoutput);

            var output = finalout.ToString();

            var enc = new ASCIIEncoding();
            var bytes = enc.GetByteCount(output);

            var outputPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            if (outputPath == null) return;
            outputPath = singlefile ? Path.Combine(outputPath, Path.GetFileNameWithoutExtension(paths[0]) + ".txt") : Path.Combine(outputPath, "output.txt");

            var fs = File.Create(outputPath, bytes);
            fs.Write(enc.GetBytes(output), 0, bytes);
            fs.Close();

            Console.WriteLine("You may now close the program.");
            Console.Read();
        }
    }

    // ReSharper disable once InconsistentNaming
    internal struct studiohdr_t
    {
        public int Id;
        public int Version;
        public char[] Name;
        public int Datalength;
        public int Flags;
    }

    internal class Mdl
    {
        private static void ReadTextures(BinaryReader reader, StringBuilder output, int offset, int count)
        {
            reader.BaseStream.Seek(offset, SeekOrigin.Begin);

            var diroffset = reader.ReadInt32();

            reader.BaseStream.Seek(offset + diroffset, SeekOrigin.Begin);
            for(var i = 0; i < count; i++)
            {
                output.AppendLine(ReadNullTerminatedString(reader));
            }
        }

        private static string ReadNullTerminatedString(BinaryReader reader)
        {
            var sb = new StringBuilder();
            while (true)
            {
                var ch = reader.ReadChar();
                if(ch == char.MinValue)
                    break;

                sb.Append(ch);
            }
            return sb.ToString();
        }

        private static void ReadTextureDirs(BinaryReader reader, StringBuilder output, int offset, int count)
        {
            reader.BaseStream.Seek(offset, SeekOrigin.Begin);

            var offsets = new List<int>();
            for (var i = 0; i < count; i++)
            {
                offsets.Add(reader.ReadInt32());
            }

            foreach (var diroffset in offsets)
            {
                reader.BaseStream.Seek(diroffset, SeekOrigin.Begin);
                output.AppendLine(ReadNullTerminatedString(reader));
            }
        }

        public static void Read(BinaryReader reader, StringBuilder texoutput, StringBuilder diroutput)
        {
            var mdl = new studiohdr_t(); // Create a new struct
						
			//Start of reading, we're at the first byte

            mdl.Id = reader.ReadInt32(); // Read ID (not used by us)
            mdl.Version = reader.ReadInt32(); // Read Version (not used by us)

            reader.ReadInt32(); // Unknown

            mdl.Name = reader.ReadChars(64); // Read Name (not used by us)
            mdl.Datalength = reader.ReadInt32(); // Read Datalength (not used by us)
            Console.WriteLine("(Version: " + mdl.Version + ")");

            reader.ReadBytes(72); // Some vector shit (not used by us)

            mdl.Flags = reader.ReadInt32(); // Read Flags (not used by us)

            reader.ReadBytes(48); // Unknown

            var texcount = reader.ReadInt32(); // Reads the amount of textures
            var texoffset = reader.ReadInt32(); // Reads the offset where we can find the textures

            var texdircount = reader.ReadInt32(); // Reads the amount of texturedirectories
            var texdiroffset = reader.ReadInt32(); // Read the offset where we can find texturedirectories

            ReadTextures(reader, texoutput, texoffset, texcount);
            ReadTextureDirs(reader, diroutput, texdiroffset, texdircount);
        }
    }
}
