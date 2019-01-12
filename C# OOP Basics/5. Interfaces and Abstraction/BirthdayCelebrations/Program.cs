using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ICreatureInfo> creatures = new List<ICreatureInfo>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] tokens = input.Split();
                if (tokens[0]=="Pet")
                {
                    
                        Pet pet = new Pet(tokens[1], tokens[2]);
                        creatures.Add(pet);
                    
                    
                }
                else if(tokens[0]=="Citizen")
                {
                    Citizen citizen = new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3],tokens[4]);
                    creatures.Add(citizen);
                }

                input = Console.ReadLine();
            }

            string year = Console.ReadLine();

            Console.WriteLine(string.Join("\n", creatures.Where(x => x.Birthdate.EndsWith(year))
                .Select(x => x.Birthdate)));
            creatures.RemoveAll(x => x.Birthdate.EndsWith(year));
        }
    }
}
