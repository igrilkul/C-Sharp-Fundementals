using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> carsList = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for(int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string model = tokens[0];
                double fuelAmount = double.Parse(tokens[1]);
                double fuelPerKm = double.Parse(tokens[2]);

                Car car = new Car(model, fuelAmount, fuelPerKm);
                carsList.Add(car);
            }

            string input = Console.ReadLine();
            while(input!="End")
            {
                string[] tokens = input.Split();
                string model = tokens[1];
                int distance = int.Parse(tokens[2]);

                carsList.Find(x=>x.Model==model).CanTravel(distance);

                input = Console.ReadLine();
            }

            foreach(var car in carsList)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.KmsTravelled}");
            }

            Console.ReadLine();
        }
    }
}
