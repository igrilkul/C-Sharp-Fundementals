using System;
using System.Collections.Generic;
using System.Linq;

//ToDo  make code more readable, try catches, pray to jesus
namespace MilitaryElite
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Private> privates = new List<Private>();
            string input = Console.ReadLine();
            while(input!="End")
            {
                string[] tokens = input.Split();

                GetAndPrintCurArmyMan(privates, tokens);

                input = Console.ReadLine();
            }
        }

        private static void GetAndPrintCurArmyMan(List<Private> privates, string[] tokens)
        {
            switch (tokens[0])
            {
                case "Private":
                    {
                        Private privatex = new Private
                            (int.Parse(tokens[1]), tokens[2], tokens[3], decimal.Parse(tokens[4]));
                        privates.Add(privatex);

                        Console.WriteLine(privatex.ToString());

                        break;
                    }
                case "LieutenantGeneral":
                    {
                        LieutenantGeneral general = new LieutenantGeneral
                            (int.Parse(tokens[1]), tokens[2], tokens[3], decimal.Parse(tokens[4]));

                        for (int i = 5; i < tokens.Length; i++)
                        {
                            var privateToAdd = privates.Find(x => x.Id == int.Parse(tokens[i]));
                            general.Privates.Add(privateToAdd);
                        }

                        Console.WriteLine(general.ToString());
                        break;
                    }
                case "Engineer":
                    {

                        try
                        {
                            Engineer engineer = new Engineer
                              (int.Parse(tokens[1]), tokens[2], tokens[3], decimal.Parse(tokens[4]), tokens[5]);

                            GetRepairs(tokens, engineer);

                            Console.WriteLine(engineer.ToString());
                            break;
                        }
                        catch (ArgumentException)
                        {
                            break;
                        }

                    }
                case "Commando":
                    {
                        try
                        {
                            Commando commando = new Commando
                            (int.Parse(tokens[1]), tokens[2], tokens[3], decimal.Parse(tokens[4]), tokens[5]);

                            GetMissions(tokens, commando);

                            Console.WriteLine(commando.ToString());
                            break;
                        }
                        catch (ArgumentException)
                        {
                            break;
                        }

                    }
                case "Spy":
                    {
                        Spy spy = new Spy
                            (int.Parse(tokens[1]), tokens[2], tokens[3], int.Parse(tokens[4]));

                        Console.WriteLine(spy.ToString());

                        break;
                    }
            }
        }

        private static void GetMissions(string[] tokens, Commando commando)
        {
            for (int i = 6; i < tokens.Length; i += 2)
            {
                try
                {
                    Mission mission = new Mission(tokens[i], tokens[i + 1]);
                    commando.Missions.Add(mission);
                }
                catch (ArgumentException)
                {
                    continue;
                }

            }
        }

        private static void GetRepairs(string[] tokens, Engineer engineer)
        {
            for (int i = 6; i < tokens.Length; i += 2)
            {
                Repair repair = new Repair(tokens[i], int.Parse(tokens[i + 1]));
                engineer.Repairs.Add(repair);
            }
        }
    }
}
