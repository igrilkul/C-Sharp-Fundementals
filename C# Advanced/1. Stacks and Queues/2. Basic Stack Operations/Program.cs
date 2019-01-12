using System;
using System.Collections.Generic;

namespace _2._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstLine = Console.ReadLine().Split(' ');

            var n = int.Parse(firstLine[0]);
            var s = int.Parse(firstLine[1]);
            var x = int.Parse(firstLine[2]);

            string[] secondLine = Console.ReadLine().Split(' ');

            var ints = new Stack<int>();

            foreach(var number in secondLine)
            {
                ints.Push(int.Parse(number));
            }

            for(var i=0;i<s;i++)
            {
                ints.Pop();
            }

            if(ints.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                if(ints.Count == 0)
                {
                    Console.WriteLine("0");
                }
                else
                {
                    var lowestNumber = ints.Pop();

                    while (ints.Count > 0)
                    {
                        var cur = ints.Pop();
                        if (cur < lowestNumber)
                        {
                            lowestNumber = cur;
                        }
                    }

                    Console.WriteLine(lowestNumber);
                }
                
            }

            Console.ReadKey();

        }
    }
}
