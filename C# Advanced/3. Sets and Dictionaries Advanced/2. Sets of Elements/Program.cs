using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();

           

            var n = new HashSet<int>();
            var m = new HashSet<int>();

            for(int i=0;i<sizes[0];i++)
            {
                n.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < sizes[1]; i++)
            {
                m.Add(int.Parse(Console.ReadLine()));
            }

            n.IntersectWith(m);
            foreach (var item in n)
            {
                Console.Write(item + " ");
            }
            Console.ReadLine();
        }
    }
}
  
