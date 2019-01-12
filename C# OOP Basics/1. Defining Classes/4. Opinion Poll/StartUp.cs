﻿using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
       public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family family = new Family();

            for(int i=0;i<n;i++)
            {
                string[] tokens = Console.ReadLine().Split();
                Person member = new Person(int.Parse(tokens[1]), tokens[0]);
                family.AddMember(member);
            }

            List<Person> thirties = family.GetOlderThanThirties();
            foreach(var person in thirties)
            {
                Console.WriteLine(person.Name+" - " +person.Age);
            }
        }
    }
}
