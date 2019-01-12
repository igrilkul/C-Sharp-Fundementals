using System;
using System.Linq;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            string input;
            while((input=Console.ReadLine())!="END")
            {
                if(input=="Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch(InvalidOperationException ie)
                    {
                        Console.WriteLine(ie.Message);
                    }
                }
                else
                {
                    int[] elements = input.Split(new char[] { ' ', ',' },StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(int.Parse).ToArray();
                    foreach(var element in elements)
                    {
                        stack.Push(element);
                    }
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine,stack));
            Console.WriteLine(string.Join(Environment.NewLine,stack));
        }
    }
}
