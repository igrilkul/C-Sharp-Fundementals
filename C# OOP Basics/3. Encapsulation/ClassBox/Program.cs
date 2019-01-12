using System;

namespace ClassBox
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Box box = new Box(length, width, height);

            Console.WriteLine($"Surface Area - {box.GetSurface():F2}");
            Console.WriteLine($"Lateral Surface Area - {box.GetLateralSurface():F2}");
            Console.WriteLine($"Volume - {box.GetVolume():F2}");

            Console.ReadLine();
        }
    }
}
