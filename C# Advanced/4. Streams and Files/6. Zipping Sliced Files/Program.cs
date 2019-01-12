using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace _6._Zipping_Sliced_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            var paths = new List<string>();
            string sourceFile = "sliceMe.mp4";
            string destination = "";
            int parts = 4;
            Slice(sourceFile, destination, parts, paths);

            string destinationAssembled = "Assembled.mp4";
            Assemble(paths, destinationAssembled);
        }

        static void Slice(string sourceFile, string destinationDirectory, int parts, List<string> paths)
        {
            using (FileStream readFile = new FileStream(sourceFile, FileMode.Open))
            {
                long size = readFile.Length / parts + readFile.Length % parts;
                byte[] buffer = new byte[size];

                for (int i = 0; i < parts; i++)
                {
                    string path = destinationDirectory + $"File-part{i}.mp4";
                    paths.Add(path);

                    using (GZipStream zipStream = new GZipStream(new FileStream(path+".gz",FileMode.Create), CompressionMode.Compress, false))
                    {
                        int bytesCount = readFile.Read(buffer, 0, buffer.Length);
                        zipStream.Write(buffer, 0, buffer.Length);
                    }
                   
                }
            }
        }

        static void Assemble(List<string> paths, string destinationDirectory)
        {
            byte[] buffer = new byte[1024];

            using (FileStream writeFile = new FileStream(destinationDirectory, FileMode.Create))
            {
                foreach (var path in paths)
                {
                    
                        //byte[] buffer = new byte[readFile.Length];
                        //readFile.Read(buffer, 0, buffer.Length);
                        //writeFile.Write(buffer, 0, buffer.Length);

                        using (Stream csStream = new GZipStream(new FileStream(path+".gz",FileMode.Open), CompressionMode.Decompress))
                        {
                            while(true)
                            {
                            int bytesCount = csStream.Read(buffer, 0, buffer.Length);

                            if(bytesCount==0)
                            {
                                break;
                            }

                            writeFile.Write(buffer, 0, bytesCount);
                            }
                          
                        }
                    
                }
            }
        }
    }
}
