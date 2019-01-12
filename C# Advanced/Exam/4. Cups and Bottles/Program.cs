using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>();
            int[] cupsArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for(int i=0;i<cupsArray.Length;i++)
            {
                cups.Enqueue(cupsArray[i]);
            }

            Stack<int> bottles = new Stack<int>();
            int[] bottlesArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < bottlesArray.Length; i++)
            {
                bottles.Push(bottlesArray[i]);
            }

            int wastedWater = 0;
            int curCup = 0;
            while(true)
            {
                //curCup has been filled to some extent
                if(!(curCup==0))
                {
                    //curCup is filled and wasted
                    if (curCup - bottles.Peek() <= 0)
                    {
                        wastedWater += bottles.Peek() - curCup;
                        cups.Dequeue();
                        bottles.Pop();
                        curCup = 0;
                        if (isLastBottle(bottles))
                        {
                            Console.WriteLine($"Cups: {string.Join(" ", cups)}");
                            Console.WriteLine($"Wasted litters of water: {wastedWater}");
                            Console.ReadLine();

                            return;
                        }
                        if (isLastCup(cups))
                        {
                            Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
                            Console.WriteLine($"Wasted litters of water: {wastedWater}");

                            Console.ReadLine();

                            return;
                        }
                    }
                    else
                    {
                     //curCup is still bigger than bottle
                     
                     curCup -= bottles.Pop();
                        
                        if (isLastBottle(bottles))
                        {
                            Console.WriteLine($"Cups: {string.Join(" ", cups)}");
                            Console.WriteLine($"Wasted litters of water: {wastedWater}");
                            Console.ReadLine();
                            return;
                        }
                    }
                }
                else //curCup is new ==0
                {
                    //curCup is filled and bottle is wasted
                    if (cups.Peek() - bottles.Peek() <= 0)
                    {
                        wastedWater += bottles.Peek() - cups.Peek();
                        cups.Dequeue();
                        bottles.Pop();
                        curCup = 0;
                        if (isLastBottle(bottles))
                        {
                            Console.WriteLine($"Cups: {string.Join(" ", cups)}");
                            Console.WriteLine($"Wasted litters of water: {wastedWater}");
                            Console.ReadLine();

                            return;
                        }
                        if (isLastCup(cups))
                        {
                            Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
                            Console.WriteLine($"Wasted litters of water: {wastedWater}");

                            Console.ReadLine();

                            return;
                        }
                    }
                    else
                    {
                        //new cup is NOT completely filled
                        curCup = cups.Peek() - bottles.Pop();
                        if (isLastBottle(bottles))
                        {
                            Console.WriteLine($"Cups: {string.Join(" ", cups)}");
                            Console.WriteLine($"Wasted litters of water: {wastedWater}");
                            Console.ReadLine();
                            return;
                        }
                    }
                }
                
               
            }
        }

        public static bool isLastCup(Queue<int> cups)
        {
            return (cups.Count == 0);
        }

        public static bool isLastBottle(Stack<int> bottles)
        {
            return (bottles.Count == 0);
        }
    }
}
