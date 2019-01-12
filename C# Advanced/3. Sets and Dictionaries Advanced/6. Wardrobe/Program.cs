using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            int n= int.Parse(Console.ReadLine());

            for(int i=0;i<n;i++)
            {
                string[] input = Console.ReadLine().Split(" -> ").ToArray();
                string[] items = input[1].Split(',').ToArray();

                string color = input[0];

                if (!wardrobe.ContainsKey(color))
                {
                    Dictionary<string, int> colored = new Dictionary<string, int>();
                    for (int c = 0; c < items.Length; c++)
                    {
                        if (!colored.ContainsKey(items[c]))
                        {
                            colored.Add(items[c], 1);
                        }
                        else
                        {
                            colored[items[c]]++;
                        }
                    }

                    wardrobe.Add(color, colored);
                }
                else
                {
                    for (int c = 0; c < items.Length; c++)
                    {
                        if (!wardrobe[color].ContainsKey(items[c]))
                        {
                            wardrobe[color].Add(items[c], 1);
                        }
                        else
                        {
                            wardrobe[color][items[c]]++;
                        }
                    }
                }
            }

            string[] lookingFor = Console.ReadLine().Split().ToArray();

            foreach(var colour in wardrobe)
            {
                Console.WriteLine($"{colour.Key} clothes:");
                foreach(var kvp in colour.Value)
                {
                    if(colour.Key==lookingFor[0] && kvp.Key==lookingFor[1])
                    {
                        Console.WriteLine($"* {kvp.Key} - {kvp.Value} (found!)");
                    }
                    else
                    {
                    Console.WriteLine($"* {kvp.Key} - {kvp.Value}");
                    }
                }
            }
        }
    }
}
