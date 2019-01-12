using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string input;
            while((input=Console.ReadLine())!="END")
            {
                string[] tokens = input.Split();
                Person person = new Person(tokens[0], int.Parse(tokens[1]), tokens[2]);
                people.Add(person);
            }

            int n = int.Parse(Console.ReadLine())-1;

            Person target = people[n];
            int matches = 0;
            foreach(var person in people)
            {

                if(person.CompareTo(people[n]) ==0)
                {
                    matches++;
                }
            }

            if(matches<2)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{matches} {people.Count-matches} {people.Count}");
            }
        }
    }
}
