using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._List_of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] dividents = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int, int[], bool> divider = dividingFunc;

            List<int> nums = new List<int>();

            for(int i=1;i<=n;i++)
            {
                if(divider(i,dividents))
                {
                    nums.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ",nums));
        }

       public  static bool dividingFunc(int n, int[] divider)
        {
            for(int i=0;i<divider.Length;i++)
            {
                if(n%divider[i]!=0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
