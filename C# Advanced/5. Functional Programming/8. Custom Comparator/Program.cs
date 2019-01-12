using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> sorter = (a, b) =>
              (a % 2 == 0 && b % 2 != 0) ? -1 :
              (a % 2 != 0 && b % 2 == 0) ? 1 :
              a.CompareTo(b);

            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Array.Sort(nums, new Comparison<int>(sorter));

            Console.WriteLine(string.Join(" ",nums));
        }
    }
}
