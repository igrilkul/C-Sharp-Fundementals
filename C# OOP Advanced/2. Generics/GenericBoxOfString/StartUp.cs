using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericBoxOfString
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input;
            Box<string> box = new Box<string>();

            while((input=Console.ReadLine())!="END")
            {
                string[] tokens = input.Split();
                switch(tokens[0])
                {
                    case "Add":
                        {
                            box.Add(tokens[1]);
                            break;
                        }
                    case "Remove":
                        {
                            box.Remove(ulong.Parse(tokens[1]));
                            break;
                        }
                    case "Contains":
                        {
                            Console.WriteLine(box.Contains(tokens[1]));
                            break;
                        }
                    case "Swap":
                        {
                            box.Swap(ulong.Parse(tokens[1]), ulong.Parse(tokens[2]));
                            break;
                        }
                    case "Greater":
                        {
                            Console.WriteLine(box.GreaterThan(tokens[1]));
                            break;
                        }
                    case "Max":
                        {
                            Console.WriteLine(box.Max());
                            break;
                        }
                    case "Min":
                        {
                            Console.WriteLine(box.Min());
                            break;
                        }
                    case "Print":
                        {
                            Console.Write(box);
                            break;
                        }
                    case "Sort":
                        {
                            box.Sort();
                            break;
                        }
                }
            }
        }
    }
}
