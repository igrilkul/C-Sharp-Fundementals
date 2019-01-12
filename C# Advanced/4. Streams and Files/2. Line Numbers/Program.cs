using System;
using System.IO;

namespace _2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            using (StreamReader reader = new StreamReader("text.txt"))
            {
                using (StreamWriter writer = new StreamWriter("output.txt"))
                {
                    int counter = 1;
                    string line = reader.ReadLine();
                    
                    while (line != null)
                    {
                        writer.WriteLine($"Line {counter}:" + line);
                        counter++;
                        line = reader.ReadLine();
                    }
                }
            }

        }
    }
}
