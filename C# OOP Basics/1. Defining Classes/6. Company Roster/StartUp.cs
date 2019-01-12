using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
       public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Employee> roster = new List<Employee>();
            for(int i=0;i<n;i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string name = tokens[0];
                decimal salary = decimal.Parse(tokens[1]);
                string position = tokens[2];
                string department = tokens[3];
                
                if(tokens.Length==5)
                {
                    if(tokens[4].Contains('@'))
                    {
                        string email = tokens[4];
                        Employee employee = new Employee(name, salary, position, department, email);
                        roster.Add(employee);
                    }
                    else
                    {
                        int age = int.Parse(tokens[4]);
                        Employee employee = new Employee(name, salary, position, department, age);
                        roster.Add(employee);

                    }
                }
                else if(tokens.Length==6)
                {
                    string email = tokens[4];
                    int age = int.Parse(tokens[5]);
                    Employee employee = new Employee(name, salary, position, department, email,age);
                    roster.Add(employee);
                }
                else
                {
                    Employee employee = new Employee(name, salary, position, department);
                    roster.Add(employee);
                }
            }


            var result = roster.GroupBy(x => x.Department)
                .ToDictionary(x => x.Key, y => y.Select(s => s))
                .OrderByDescending(x => x.Value.Average(s => s.Salary))
                .FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {result.Key}");
            foreach(var person in result.Value.OrderByDescending(x=>x.Salary))
            {
                Console.WriteLine($"{person.Name} {person.Salary:F2} {person.Email} {person.Age}");
            }


            Console.ReadLine();
        }
    }
}
