using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();


            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] tokens = command.Split();
                var department = tokens[0];
                var firstName = tokens[1];
                var secondName = tokens[2];
                var patient = tokens[3];
                var fullName = firstName + secondName;

                if (!doctors.ContainsKey(fullName))
                {
                    doctors[fullName] = new List<string>();
                }
                if (!departments.ContainsKey(department))
                {
                    departments[department] = new List<List<string>>();
                    for (int rooms = 0; rooms < 20; rooms++)
                    {
                        departments[department].Add(new List<string>());
                    }
                }

                if (HasRoom(departments, department))
                {
                    int room = 0;
                    doctors[fullName].Add(patient);

                    room = FindRoom(departments, department, room);

                    departments[department][room].Add(patient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();

                PrintOutput(doctors, departments, args);

                command = Console.ReadLine();
            }

            Console.ReadLine();
        }

        private static void PrintOutput(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string[] args)
        {
            if (args.Length == 1)
            {
                Console.WriteLine(string.Join("\n", departments[args[0]].Where(x => x.Count > 0).SelectMany(x => x)));
            }
            else if (args.Length == 2 && int.TryParse(args[1], out int staq))
            {
                Console.WriteLine(string.Join("\n", departments[args[0]][staq - 1].OrderBy(x => x)));
            }
            else
            {
                Console.WriteLine(string.Join("\n", doctors[args[0] + args[1]].OrderBy(x => x)));
            }
        }

        private static int FindRoom(Dictionary<string, List<List<string>>> departments, string department, int room)
        {
            for (int st = 0; st < departments[department].Count; st++)
            {
                if (departments[department][st].Count < 3)
                {
                    room = st;
                    break;
                }
            }

            return room;
        }

        private static bool HasRoom(Dictionary<string, List<List<string>>> departments, string department)
        {
            return departments[department].SelectMany(x => x).Count() < 60;
        }
    }
}
