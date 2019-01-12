using System;
using System.Linq;

namespace _1._Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (string name in names)
            {
                print(name);
            }
        }

            public static Action<string> print = message => Console.WriteLine(message);
    }

       
    
}

