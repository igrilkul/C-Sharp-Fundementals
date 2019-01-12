using System;
using System.IO;

namespace _1._Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {

            using (StreamReader reader = new StreamReader("text.txt"))
            {
                int counter = 0;
                string line = reader.ReadLine();
                while(line!=null)
                {
                    if(counter%2!=0)
                    {
                        Console.WriteLine(line);
                    }
                    counter++;
                    line = reader.ReadLine();
                }
            }

            Console.ReadLine();
        }
    }
}
