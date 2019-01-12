using System;

namespace _5._Date_Modifier
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string dateOne = Console.ReadLine();
            string dateTwo = Console.ReadLine();

            DateModifier dm = new DateModifier();
            Console.WriteLine(dm.DifferenceCalculator(dateOne, dateTwo));
        }
    }
}
