using System;
using System.Collections.Generic;

namespace _3._Maximum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
           int n = int.Parse(Console.ReadLine());

            Stack<int> stecky = new Stack<int>();
            for(var i=0;i<n;i++)
            {
                var element=0;
                var query = Console.ReadLine().Split();
                int queryType = int.Parse(query[0]);
                if (query.Length > 1)
                { element = int.Parse(query[1]); }

                switch(queryType)
                {
                    case 1:
                        {
                            stecky.Push(element);
                            break;
                        }

                    case 2:
                        {
                            stecky.Pop();
                            break;
                        }

                    case 3:
                        {
                            int max=stecky.Peek();
                            foreach(var number in stecky)
                            {
                                if(number > max)
                                {
                                    max = number;
                                }
                            }

                            Console.WriteLine(max);
                            break;
                        }
                }
            }
        }
    }
}
