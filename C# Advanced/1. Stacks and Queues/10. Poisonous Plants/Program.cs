using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Poisonous_Plants
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] plants = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var mainStack = new Stack<int>(plants);
            var secondQueue = new Stack<int>();
            bool plantDied = true;
            int day;
            for(day=1;plantDied==true;day++)
            {
                plantDied = false;
                //Checks which plants die and pushes to second stack
                for (int i = 0; i < n-1; i++)
                {
                    int plantB = mainStack.Pop();
                    int plantA = mainStack.Peek();

                    if (plantA >= plantB)
                    {
                        secondQueue.Push(plantB);
                    }
                    else
                    {
                        plantDied = true;
                    }


                }

                secondQueue.Push(mainStack.Pop());

                //fill back main stack with survived plants and clear second stack
                int cycles = secondQueue.Count;
                for(int i=0;i<cycles;i++)
                {
                    mainStack.Push(secondQueue.Pop());
                }


                n = mainStack.Count;
            }

            Console.WriteLine(day-2);
            Console.ReadKey();
           
            
                
            
        }
    }
}
