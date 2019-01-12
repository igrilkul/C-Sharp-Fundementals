using System;
using System.Collections.Generic;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<Person> peopleByName = new SortedSet<Person>(new PersonByName());
            SortedSet<Person> peopleByAge = new SortedSet<Person>(new PersonByAge());


            for(int i=0;i<n;i++)
            {
                string[] tokens = Console.ReadLine().Split();

                Person person = new Person(tokens[0], int.Parse(tokens[1]));
                peopleByName.Add(person);
                peopleByAge.Add(person);
            }

            Console.WriteLine(string.Join(Environment.NewLine,peopleByName));
            Console.WriteLine(string.Join(Environment.NewLine,peopleByAge));
        }
    }
}
