using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            Func<List<int>,List<int>> add = n =>n.Select(x=>x+1).ToList();
            Func<List<int>,List<int>> Multiply = n => n.Select(x=>x*2).ToList();
            Func<List<int>, List<int>> Subtract = n => n.Select(x => x-1).ToList();
            Action<List<int>> Print = n => Console.WriteLine(string.Join(" ",n));


            string input;
        while((input=Console.ReadLine()) !="end")
            {
               
                switch(input)
                {
                    case "add":
                        {
                           nums=add(nums);
                            break;
                        }
                    case "multiply":
                        {
                            nums = Multiply(nums);
                            break;
                        }
                    case "subtract":
                        {
                            nums = Subtract(nums);
                            break;
                        }
                    case "print":
                        {
                            Print(nums);
                            break;
                        }
                    
                }
            }
            
        }
    }
}
