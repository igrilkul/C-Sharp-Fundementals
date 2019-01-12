using System;
using System.Collections.Generic;

namespace _5._Calculate_Sequence_with_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            var que = new Queue<long>(51);
            var spareQue = new Queue<long>();

            var s1 = n;

            que.Enqueue(s1);
            spareQue.Enqueue(s1);


            for(int i=1; i<=17;i++)
            {
                var s2 = s1 + 1;
                var s3 = 2 * s1 + 1;
                var s4 = s1 + 2;

                que.Enqueue(s2);
                que.Enqueue(s3);
                que.Enqueue(s4);

                spareQue.Enqueue(s2);
                spareQue.Enqueue(s3);
                spareQue.Enqueue(s4);

                spareQue.Dequeue();
                s1 = spareQue.Peek();
            }

            for(int i=0;i<50;i++)
            {
                Console.Write(que.Dequeue() + " ");
            }

            Console.ReadKey();
        }
    }
}
 