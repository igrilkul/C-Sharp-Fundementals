using System;

namespace Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carTokens = Console.ReadLine().Split();
            string[] truckTokens = Console.ReadLine().Split();
            string[] busTokens = Console.ReadLine().Split();

            Vehicle car = new Car
                (double.Parse(carTokens[1]), double.Parse(carTokens[2]),double.Parse(carTokens[3]));

            Vehicle truck = new Truck
                (double.Parse(truckTokens[1]), double.Parse(truckTokens[2]),double.Parse(truckTokens[3]));

            Vehicle bus = new Bus
                (double.Parse(busTokens[1]), double.Parse(busTokens[2]), double.Parse(busTokens[3]));

            int n = int.Parse(Console.ReadLine());

            for(int i=0;i<n;i++)
            {
                string[] tokens = Console.ReadLine().Split();

                string action = tokens[0];
                string vehicle = tokens[1];
                double value = double.Parse(tokens[2]);

                if(action=="Drive")
                {
                    if(vehicle=="Car")
                    {
                        car.Drive(value);
                    }
                    else if(vehicle=="Bus")
                    {
                        bus.DrivingWithPeople(value);
                    }
                    else
                    {
                        truck.Drive(value);
                    }
                }
                else if(action=="Refuel")
                {
                    if (vehicle == "Car")
                    {
                        car.Refuel(value);
                    }
                    else if(vehicle=="Bus")
                    {
                        bus.Refuel(value);
                    }
                    else
                    {
                        truck.Refuel(value);
                    }
                }
                else
                {
                    bus.DrivingWithoutPeople(value);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);

        }
    }
}
