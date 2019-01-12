using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, int, List<int>> reverser = delegate (List<int> list, int divident)
             {
                 list.Reverse();
                return list.Where(x => x % divident != 0).ToList();
             };

            var nums=Console.ReadLine().Split().Select(int.Parse).ToList();
            int divider = int.Parse(Console.ReadLine());
            
            Console.WriteLine(string.Join(" ",reverser(nums,divider)));
        }
    }
}
