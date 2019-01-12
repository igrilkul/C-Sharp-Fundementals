using System;
using System.Collections.Generic;

namespace _1._Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> usernames = new HashSet<string>();

            for(int i=0;i<n;i++)
            {
                usernames.Add(Console.ReadLine());
            }

            Console.WriteLine(String.Join("\n", usernames));
            Console.ReadLine();
        }
    }
}
