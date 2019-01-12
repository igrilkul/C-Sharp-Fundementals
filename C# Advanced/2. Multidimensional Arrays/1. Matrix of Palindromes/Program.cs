using System;
using System.Linq;

namespace _1._Matrix_of_Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[] alphabet ="abcdefghijklmnopqrstuvwxyz".ToCharArray();
            string[,] palindromes = new string[input[0],input[1]];

            for(int i=0;i<input[0];i++)
            {
                for(int k=0;k<input[1];k++)
                {
                    palindromes[i, k] = alphabet[i].ToString() + alphabet[k+i].ToString() + alphabet[i].ToString();
                }
            }

            for (int i = 0; i < input[0]; i++)
            {
                for (int k = 0; k < input[1]; k++)
                {
                    Console.Write(palindromes[i,k]+" ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();

        }
    }
}
