using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> table = new SortedSet<string>();
            for (int i=0;i<n;i++)
            {
                string[] input=Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                foreach(string element in input)
                {
                    table.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ",table));

        }
    }
}
