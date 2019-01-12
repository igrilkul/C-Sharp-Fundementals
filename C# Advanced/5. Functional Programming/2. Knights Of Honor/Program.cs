using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2._Knights_Of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            new Regex(@"[ \t]")
                .Split(Console.ReadLine())
                .Where(s => s != String.Empty)
                .ToList()
                .ForEach(BeKnight);

            Console.ReadLine();
        }
        public static Action<string> BeKnight { get; set; } = name => Console.WriteLine("Sir " + name);
    }
}


