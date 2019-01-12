using System;

namespace AnimalCentre
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            AnimalCentre ac = new AnimalCentre();
            //TODO Run your application from here
            string input;
            while((input=Console.ReadLine())!="End")
            {
                string[] tokens = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    switch (tokens[0])
                    {
                        case "RegisterAnimal":
                            {
                                Console.WriteLine(ac.RegisterAnimal
      (tokens[1], tokens[2], int.Parse(tokens[3]), int.Parse(tokens[4]), int.Parse(tokens[5])));
                                break;
                            }
                        case "Chip":
                            {
                                Console.WriteLine(ac.Chip(tokens[1], int.Parse(tokens[2])));
                                break;
                            }
                        case "Vaccinate":
                            {
                                Console.WriteLine(ac.Vaccinate(tokens[1], int.Parse(tokens[2])));
                                break;
                            }
                        case "Fitness":
                            {
                                Console.WriteLine(ac.Fitness(tokens[1], int.Parse(tokens[2])));
                                break;
                            }
                        case "Play":
                            {
                                Console.WriteLine(ac.Play(tokens[1], int.Parse(tokens[2])));
                                break;
                            }
                        case "DentalCare":
                            {
                                Console.WriteLine(ac.DentalCare(tokens[1], int.Parse(tokens[2])));
                                break;
                            }
                        case "NailTrim":
                            {
                                Console.WriteLine(ac.NailTrim(tokens[1], int.Parse(tokens[2])));
                                break;
                            }
                        case "Adopt":
                            {
                                Console.WriteLine(ac.Adopt(tokens[1], tokens[2]));
                                break;
                            }
                        case "History":
                            {
                                Console.WriteLine(ac.History(tokens[1]));
                                break;
                            }
                    }
                }
                catch(InvalidOperationException io)
                {
                    Console.WriteLine($"InvalidOperationException: {io.Message}");
                }
                catch(ArgumentException ae)
                {
                    Console.WriteLine($"ArgumentException: {ae.Message}");
                }
                
            }

            ac.PrintCentre();
        }
    }
}
