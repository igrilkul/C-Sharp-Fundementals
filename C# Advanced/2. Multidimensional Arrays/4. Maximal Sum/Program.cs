using System;
using System.Linq;

namespace _4._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(new[]{ ' ' },StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var matrix = new int[input[0]][];
            for(int i=0;i<input[0];i++)
            {
                matrix[i] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            }

            int maxSum = int.MinValue;
            int topI = -1;
            int topK = -1;

            for(int i=0;i<=input[0]-3;i++)
            {
                for(int k=0;k<=input[1]-3;k++)
                {
                    int curSum = (matrix[i][k] + matrix[i][k + 1] + matrix[i][k + 2] + matrix[i + 1][k]
                        + matrix[i + 1][k + 1] + matrix[i + 1][k + 2] + matrix[i + 2][k]
                        + matrix[i + 2][k + 1] + matrix[i + 2][k + 2]);

                    if (curSum>maxSum)
                    {
                        maxSum = curSum;
                        topI = i;
                        topK = k;
                    }
                }
            }

            Console.WriteLine("Sum = " + maxSum);
            for (int i = topI; i < topI + 3; i++)
            {
                for (int k = topK; k < topK + 3; k++)
                {
                    Console.Write(matrix[i][k] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
