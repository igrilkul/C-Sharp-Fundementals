using System;
using System.Linq;

namespace _7._Lego_Blocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[][] jaggedLeft = new int[n][];
            for (int i=0;i<n;i++)
            {
                jaggedLeft[i] = 
                 Console.ReadLine().Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            int[][] jaggedRight = new int[n][];
            for (int i = 0; i < n; i++)
            {
                jaggedRight[i] =
                 Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            bool itFits = true;
            int firstSum = jaggedLeft[0].Length + jaggedRight[0].Length;
            for(int i=0;i<n;i++)
            {
             Array.Reverse(jaggedRight[i]);

                if(jaggedLeft[i].Length+jaggedRight[i].Length!=firstSum)
                {
                    itFits = false;
                }
            }

            if(itFits)
            {
                for(int i=0;i<n;i++)
                {
                    Console.WriteLine("["+string.Join(", ",jaggedLeft[i])+", "+string.Join(", ",jaggedRight[i])+"]");
                }
            }
            else
            {
                int sum = 0;
                for(int i=0;i<n;i++)
                {
                    sum += jaggedLeft[i].Length + jaggedRight[i].Length;
                }
                Console.WriteLine("The total number of cells is: "+sum);
            }
            Console.ReadLine();
        }
    }
}
