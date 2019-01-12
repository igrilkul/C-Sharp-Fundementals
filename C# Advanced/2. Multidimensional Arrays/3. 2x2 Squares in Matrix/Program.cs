using System;
using System.Linq;

namespace _3._2x2_Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var matrix = new string[input[0]][];

            for(int i=0;i<input[0];i++)
            {
                matrix[i] = Console.ReadLine().Split().ToArray();
            }

            int counter = 0;

            for(int i=0;i<input[0]-1;i++)
            {
                for(int k=0;k<input[1]-1;k++)
                {
                    string symbol = matrix[i][k];

                    if(symbol ==matrix[i][k+1] 
                        && symbol==matrix[i+1][k]
                        && symbol==matrix[i+1][k+1])
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
            Console.ReadLine();
        }
    }
}
