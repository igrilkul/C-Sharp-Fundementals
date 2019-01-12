using System;
using System.Collections.Generic;

namespace _4._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> list = new Dictionary<int, int>();

            for(int i=0;i<n;i++)
            {
                int num = int.Parse(Console.ReadLine());
                if(!list.ContainsKey(num))
                {
                    list.Add(num, 1);
                }
                else
                {
                    list[num]++;
                }
            }

            foreach(var kvp in list)
            {
               if(kvp.Value%2==0)
                    Console.WriteLine(kvp.Key);
            }
        }
    }
}
