using System;
using System.Collections.Generic;

namespace _5._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            SortedDictionary<char, int> counter = new SortedDictionary<char, int>();

            foreach(char character in input)
            {
                if(!counter.ContainsKey(character))
                {
                    counter.Add(character, 1);
                }
                else
                {
                    counter[character]++;
                }
            }

            foreach(var kvp in counter)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }

            Console.ReadLine();
        }
    }
}
