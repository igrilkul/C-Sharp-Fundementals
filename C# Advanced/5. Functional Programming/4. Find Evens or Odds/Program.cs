using System;
using System.Linq;

namespace _4._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, bool> isEven = n => n % 2 == 0;
            Func<int, bool> isOdd = n => n % 2 != 0;

            var minMax = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string input = Console.ReadLine();

            if(input=="odd")
            {
                var odds=Enumerable.Range(minMax[0],(minMax[1]-minMax[0])+1).Where(n => isOdd(n)).ToArray();
                Console.WriteLine(string.Join(" ",odds));
            }
            else
            {
               
                var evens = Enumerable.Range(minMax[0], (minMax[1] - minMax[0])+1).Where(n => isEven(n)).ToArray();
                Console.WriteLine(string.Join(" ", evens));
            }
            Console.ReadLine();
        }
    }
}
