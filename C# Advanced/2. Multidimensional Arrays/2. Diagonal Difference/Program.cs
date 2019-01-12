using System;
using System.Linq;

namespace _2._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] matrix = new int[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            }

            int primarySum = 0;
            int secondarySum = 0;

            for (int i = 0; i < n; i++)
            {
              

                primarySum += matrix[i][i];
                secondarySum += matrix[i][n - i - 1];
            }

            Console.WriteLine(Math.Abs(primarySum-secondarySum));

            Console.ReadLine();


        }
    }
}
