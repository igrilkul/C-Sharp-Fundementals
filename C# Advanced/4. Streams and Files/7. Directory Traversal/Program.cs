using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _7._Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles("..//");
            var directoryInfo = new Dictionary<string, Dictionary<string, decimal>>();

            foreach(string file in files)
            {
                var currentFile = File.Open(file, FileMode.Open);

                var name = Path.GetFileName(file);
                var extension =Path.GetExtension(file);
                var length = currentFile.Length;

                decimal fileSize = Decimal.Divide(length, 1024);

                if(!directoryInfo.ContainsKey(extension))
                {
                    directoryInfo.Add(extension, new Dictionary<string, decimal>());
                }

                if(!directoryInfo[extension].ContainsKey(name))
                {
                    directoryInfo[extension].Add(name, fileSize);
                }
            }

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\report.txt";

            using (StreamWriter sw = new StreamWriter(path))
            {

                foreach (var kvp in directoryInfo.OrderByDescending(x => x.Value.Count).ThenBy(k => k.Key))
                {
                    sw.WriteLine(kvp.Key);

                    foreach(var fileInfo in kvp.Value.OrderBy(x=>x.Value))
                    {
                        sw.WriteLine($"--{fileInfo.Key} - {fileInfo.Value:F2}kb");
                    }

                }
            }
        }
    }
}
