using System;

namespace Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            string[] sites = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

            Smartphone phone = new Smartphone(numbers, sites);
            Console.WriteLine(phone);
        }
    }
}
