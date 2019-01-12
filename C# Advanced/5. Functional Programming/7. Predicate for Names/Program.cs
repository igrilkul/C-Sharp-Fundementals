using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Predicate_for_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int len=int.Parse(Console.ReadLine());
            List<string> nameList = Console.ReadLine().Split().ToList();
            Predicate<string> isValid = n => n.Length <= len;

            Console.WriteLine(string.Join("\n",nameList.Where(x=>isValid(x))));
            Console.ReadLine();
        }
    }
}
