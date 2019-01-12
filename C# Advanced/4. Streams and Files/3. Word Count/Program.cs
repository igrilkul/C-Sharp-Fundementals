using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _3._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordsList = new Dictionary<string, int>();
           

            using (StreamReader reader = new StreamReader("words.txt"))
            {
                string line = reader.ReadLine().Trim().ToLower();
                while (line != null)
                {
                    if(!wordsList.ContainsKey(line))
                    {
                        wordsList.Add(line, 0);
                    }
                    line = reader.ReadLine();
                }
            }

            using (StreamReader reader = new StreamReader("text.txt"))
            {
                string text = reader.ReadToEnd().ToLower();
                if(text.Length>0)
                {
                    Regex regex = new Regex("[a-zA-Z']+");

                    foreach(Match match in regex.Matches(text))
                    {
                        if(wordsList.ContainsKey(match.Value))
                        {
                            wordsList[match.Value]++;
                        }
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter("result.txt"))
            {
                foreach(var kvp in wordsList.OrderByDescending(v=>v.Value))
                {
                    writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                }
            }


            Console.ReadLine();
        }
    }
}
