using System;
using System.Collections.Generic;

namespace _4._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
           var firstLine = Console.ReadLine().Split(' ');

            var n = int.Parse(firstLine[0]);
            var s = int.Parse(firstLine[1]);
            var x = int.Parse(firstLine[2]);

            var secondLine = Console.ReadLine().Split(' ');
            var que = new Queue<int>();

            foreach(var number in secondLine)
            {
                que.Enqueue(int.Parse(number));
            }

            for(var i =0;i<s;i++)
            {
                que.Dequeue();
            }

            if(que.Count==0)
            {
                Console.WriteLine("0");
            }
            else
            {
                if(que.Contains(x))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    var min = que.Peek();

                    foreach(var element in que)
                    {
                        if(element<min)
                        {
                            min = element;
                        }
                    }
                    Console.WriteLine(min);
                }
            }
        }
    }
}
