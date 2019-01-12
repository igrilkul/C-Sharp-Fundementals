using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> creatures = new List<Person>();
            int n = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();


            for (int i=0;i<n;i++)
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 4)
                {
                    Citizen citizen = new Citizen(tokens[0], int.Parse(tokens[1]),
                        tokens[2], tokens[3]);
                    creatures.Add(citizen);
                }
                else
                {
                    Rebel rebel = new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]);
                    creatures.Add(rebel);
                }

                input = Console.ReadLine();
            }


            while (input != "End")
            {
                var person = creatures.FirstOrDefault(c => c.Name == input);
                person?.BuyFood();

                input = Console.ReadLine();
            }

            Console.WriteLine(creatures.Sum(x=>x.Food));
        }
    }
}
