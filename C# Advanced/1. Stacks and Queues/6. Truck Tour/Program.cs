using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int[]> pumpsInfo = new Queue<int[]>();


            for (int i=0;i<n;i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                pumpsInfo.Enqueue(input);

            }

            int index = 0;
            while(true)
            {
                int totalFuel = 0;
                foreach(var currentPump in pumpsInfo)
                {
                    int fuel = currentPump[0];
                    int distance = currentPump[1];

                    totalFuel += fuel - distance;

                    if(totalFuel<0)
                    {
                        int[] pumpToRemove = pumpsInfo.Dequeue();
                        pumpsInfo.Enqueue(pumpToRemove);
                        index++;
                        break;
                    }

                }

                if(totalFuel>=0)
                {
                    Console.WriteLine(index);
                    break;
                }
            }

            Console.ReadKey();

            
        }
    }
}
