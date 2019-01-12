using System;
using System.Collections.Generic;

namespace _1._Reverse_numbers_with_a_stack
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');

            var reversedNumbers = new Stack<string>(input.Length);
            for (int i = 0; i < input.Length; i++)
            {
                reversedNumbers.Push(input[i]);
            }

            foreach (var n in reversedNumbers)
            {
                Console.Write(n + " ");
            }
            Console.ReadKey();
        }
    }
}
