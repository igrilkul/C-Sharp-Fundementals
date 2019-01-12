using System;
using System.Collections.Generic;

namespace _8._Stack_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            var FibonacciStack = new Stack<long>();
            FibonacciStack.Push(0);
            FibonacciStack.Push(1);

            long f1;
            long f2;

            int n = int.Parse(Console.ReadLine());
            for(int i=2;i<=n;i++)
            {
                f1 = FibonacciStack.Pop();
                f2 = FibonacciStack.Peek();

                FibonacciStack.Push(f1);
                FibonacciStack.Push(f1 + f2);
            }

            Console.WriteLine(FibonacciStack.Peek());

            Console.ReadKey();

        }
    }
}
