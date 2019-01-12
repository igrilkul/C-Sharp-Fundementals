using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    class Truck : Vehicle
    {
        private const double ACConsumption = 1.6;

        public Truck(double fuel,double fuelPerKm,double tank):base(fuel,fuelPerKm,tank)
        {
            this.FuelPerKm += ACConsumption;
        }

        public override void Drive(double distance)
        {
            if(this.Fuel>=this.FuelPerKm*distance)
            {
                this.Fuel -= this.FuelPerKm * distance;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }

        

        public override string ToString()
        {
            return $"{this.GetType().Name}: {Fuel:F2}";
        }
    }
}
