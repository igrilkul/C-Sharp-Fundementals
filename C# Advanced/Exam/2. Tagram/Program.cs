using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Tagram
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> database = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while(input!="end")
            {
                if(input.StartsWith("ban"))
                {
                    string username = input.Split()[1];
                    if(database.ContainsKey(username))
                    {
                        database.Remove(username);
                    }
                }
                else
                {
                    string[] tokens = input.Split(" -> ");
                    var username = tokens[0];
                    var tag = tokens[1];
                    int likes = int.Parse(tokens[2]);

                    if(!database.ContainsKey(username))
                    {
                        Dictionary<string, int> tags = new Dictionary<string, int>();
                        tags.Add(tag, likes);
                        database.Add(username, tags);
                    }
                    else
                    {
                        if(!database[username].ContainsKey(tag))
                        {
                            database[username].Add(tag, likes);
                        }
                        else
                        {
                            database[username][tag] += likes;
                        }
                    }

                }

                input = Console.ReadLine();
            }

            foreach(var user in database.OrderByDescending(x=>x.Value.Values.Sum()).ThenBy(y=>y.Value.Count))
            {
                Console.WriteLine(user.Key);
                foreach(var tag in user.Value)
                {
                    Console.WriteLine($"- {tag.Key}: {tag.Value}");
                }
            }

            Console.ReadLine();
        }
    }
}
