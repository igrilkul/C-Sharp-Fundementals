using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
           
            List<IIdentifiable> creatures = new List<IIdentifiable>();

        string input = Console.ReadLine();
            while(input!="End")
            {
                string[] tokens = input.Split();
                if(tokens.Length==2)
                {
                    Robot robot = new Robot(tokens[0], tokens[1]);
                    creatures.Add(robot);
                }
                else
                {
                    Citizen citizen = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]);
                    creatures.Add(citizen);
                }

                input = Console.ReadLine();
            }

            string fakeId = Console.ReadLine();

            Console.WriteLine(string.Join("\n",creatures.Where(x=>x.Id.EndsWith(fakeId)).Select(x=>x.Id)));
            creatures.RemoveAll(x => x.Id.EndsWith(fakeId));
        }
    }
}
